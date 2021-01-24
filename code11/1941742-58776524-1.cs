using System;
using static System.Console;
namespace a5
{
    class Program
    {
        const string acceptedLetters = "EHLNTXZ";
        static void Main(string[] args)
        {
            GetUserString(acceptedLetters);
            ReadKey();
        }
        static string GetUserString(string letters)
        {
            string invalidCharacters;
            do
            {
                invalidCharacters = null;
                Write("Enter : ");
                string inputCharacters = ReadLine();
                foreach(char c in inputCharacters) 
                {
                    if(letters.IndexOf(char.ToUpper(c))== -1)
                    {
                        invalidCharacters = c.ToString();
                    }
                }
                if(invalidCharacters != null)
                {
                    WriteLine("Enter a valid input");
                }
                
            } while (invalidCharacters != null);
			return inputCharacters;
         } 
    }
}
