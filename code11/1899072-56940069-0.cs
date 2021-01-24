    using System;
    using System.Linq;
    
    class MainClass {
        public static void Main (string[] args) {
            string str1 = "I-000146.22.43.24";
            Console.WriteLine ("{0} is a valid string: {1}", str1, isValidString(str1));
            string str2 = "I-000146.22.43.9";
            Console.WriteLine ("{0} is a valid string: {1}", str2, isValidString(str2));
            string str3 = "I-000146.22.43.a";
            Console.WriteLine ("{0} is a valid string: {1}", str3, isValidString(str3));
        }
    
        private static bool isValidString(string str) {
            var lastNumString = str.Split('.').Last();
            return isSingleDigit(lastNumString);
        }
     
        private static bool isSingleDigit(string numString) {
            int number;
            bool success = Int32.TryParse(numString, out number);
            if (success) {
                return number >= 0 && number <= 9;
            } else {
                return success;
            }
        }
    }
