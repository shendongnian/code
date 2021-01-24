    using System;
    
    namespace App.Extensions
    {
        public static class stringExt
        {
    
            private static string Reverse(String str)
            {
                char[] charArray = str.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
    
            public static bool isPalindrome(this String str)
            {
                return str == Reverse(str);
                //return str.ToUpper() == Reverse(str.ToUpper()); //use this if case shouldn't matter
            }
        }
    }
