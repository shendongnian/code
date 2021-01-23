    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Ch6ex10
    {
        class Isosceles
        {
            static void Main(string[] args)
            {            
                OutputTraiangle(InputCharacter(), InputPeak());
                Console.ReadLine();
            }
                
            //Allow user to input a character to be used as the triangle
            public static char InputCharacter()
            {
                string inputValue;
                char character;
                Console.Write("Enter the character to be used to display the  triangle: ");
                inputValue = Console.ReadLine();
                character = Convert.ToChar(inputValue);
                return character;
            }
            //Allow user to input an integer for the peak of the triangle
            public static int InputPeak()
            {
                string inputPeak;
                int peak;
                Console.Write("Enter the integer amount for the peak of the triangle: ");
                inputPeak = Console.ReadLine();
                peak = Convert.ToInt32(inputPeak);
                return peak;
            }
            //Output the triangle using the users character choice and peak size (first half)
            public static void OutputTraiangle(char character, int peak)
            {
                int start = 1;
                int finish = (peak - 1);
                while (start != peak)
                {
                    for (int amount = 1; amount <= start; amount++)
                    {
                        Console.Write(character);
                    }
                    Console.WriteLine();
                    start++;                
                }
            
                for (int amount = 1; amount <= peak; amount++)
                    {
                         Console.Write(character);
                    }
                Console.WriteLine();
                while (finish != 0)
                {
                    for (int amount = 1; amount <= finish; amount++)
                    {
                        Console.Write(character);
                    }
                    Console.WriteLine();
                    finish--;
                }            
            }
        }
    }
