    using System;
    using System.Linq;
    
    class MainClass {
        public static void Main (string[] args) {
            String[] tests = new string[3] {"I-000146.22.43.24", "I-000146.22.43.9", "I-000146.22.43.a"};
            foreach (string test in tests) {
                Console.WriteLine ($"{test} is a valid string: {isValidString (test)}");
            }
        }
    
        private static bool isValidString (string str) {
            var lastNumString = str.Split ('.').Last();
            return isSingleDigit (lastNumString);
        }
     
        private static bool isSingleDigit (string numString) {
            int number;
            bool success = Int32.TryParse (numString, out number);
            if (success) {
                return number >= 0 && number <= 9;
            }
            return success;
        }
    }
