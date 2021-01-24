    using System;
    
    public class Palindrome
    {
        public static bool IsPalindrome(string word)
        {
    
            char[] temp = word.ToCharArray();
            Array.Reverse(temp);
            string emordnilap = new string(temp);
    
            if(word.Equals(emordnilap))
            {
                return true;
            }
            else
            {
               return false; 
            }
    
        }
    
        public static void Main(string[] args)
        {
            //The ToString() converts your boolean to a string
            Console.WriteLine(Palindrome.IsPalindrome("Deleveled").ToString());
        }
    
    }
