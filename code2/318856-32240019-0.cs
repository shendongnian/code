    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Case_example_1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Char ch;
                Console.WriteLine("Enter a character");
                ch =Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
    
                        Console.WriteLine("Character is alphabet");
                        break;
    
                    default:
                        Console.WriteLine("Character is constant");
                        break;
    
                }
    
                Console.ReadLine();
    
            }
        }
    }
