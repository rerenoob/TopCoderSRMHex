using System;
using System.Collections.Generic;

namespace TopCoderSRMHex
{
    class Program
    {
        static void Main(string[] args)
        {
            string test1 = "DISEASE";
            Console.WriteLine(getLiteral(test1));
            string test2 = "TASTEFUL";
            Console.WriteLine(getLiteral(test2));
            string test3 = "ESPRIT";
            Console.WriteLine(getLiteral(test3));

        }

        static string getLiteral(string candidate)
        {
            Dictionary<char, char> encodeBook = new Dictionary<char, char>();
            encodeBook.Add('O', '0');
            encodeBook.Add('I', '1');
            encodeBook.Add('Z', '2');
            encodeBook.Add('S', '5');
            encodeBook.Add('T', '7');

            string encodedString = swapForHex(candidate, encodeBook);
            // if there's a good suffix, it's good, just return
            if (checkForSuffices(encodedString))
                return buildFinalString(encodedString);
            else if (checkForValidHex(encodedString))
            {
                return buildFinalString(encodedString);
            }
            else
            {
                return "";
            }
        }

        static bool checkForValidHex(string candidate)
        {
            try
            {
                int decValue = int.Parse(candidate, System.Globalization.NumberStyles.HexNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static string buildFinalString(string stringToBuild)
        {
            string result = "";

            result = "0x" + stringToBuild;

            return result;
        }

        static bool checkForSuffices(string candidate)
        {
            string[] suffices = new string[7] { "L", "LL", "U", "UL", "ULL", "LU", "LLU" };
            string temp = "";

            for (int i = 1; i <= 3; i++)
            {
                temp = Array.Find(suffices,
                    element => element.Equals(candidate.Substring(candidate.Length - i, i)));
                if (!string.IsNullOrEmpty(temp)){
                    return true;
                }
            }

            return false;
        }

        static string swapForHex(string stringToSwap, Dictionary<char, char> encodeBook)
        {
            string result = "";
            for(int i = 0; i < stringToSwap.Length; i++)
            {
                if (encodeBook.ContainsKey(stringToSwap[i]))
                {
                    result += encodeBook[stringToSwap[i]];
                }
                else
                {
                    result += stringToSwap[i];
                }
            }
            return result;
        }
    }
}
