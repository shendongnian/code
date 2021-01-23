    using System;
     
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string MyString = "A @string & and 2.";
     
                Console.WriteLine(MyString);
                for (int charpos = 0; charpos < MyString.Length; charpos++)
                {
                    Console.WriteLine(Char.IsLetter(MyString, charpos));    
                }
                //Keep the console on screen
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
            }
        }
    }
