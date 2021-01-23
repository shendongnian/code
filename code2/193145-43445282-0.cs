    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Practice
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] new_str = new char[50];
                string str;
                int ch;
                Console.Write("Enter String : ");
                str = Console.ReadLine();
    
                for (int i = 0; i < str.Length; i++)
                {
                    ch = (int)str[i];
                    if (ch > 64 && ch < 91)
                    {
                        ch = ch + 32;
                        new_str[i] = Convert.ToChar(ch);
                    }
                    else
                    {
                        ch = ch - 32;
                        new_str[i] = Convert.ToChar(ch);
                    }
                }
                Console.Write(new_str);
    
                Console.ReadKey();
            }
        }
    }
