    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                char drawChar = '#';
                int repeatNumber = 5;
            Program.drawIsoscelesTraiangle(drawChar, repeatNumber, 1);
            Console.ReadKey();
        }
        static void drawIsoscelesTraiangle(char repeatChar, int peak, int current)
        {
            if (current < peak)
            {
                Console.WriteLine(new string(repeatChar, current));
                Program.drawIsoscelesTraiangle(repeatChar, peak, current + 1);
                Console.WriteLine(new string(repeatChar, current));
            }
            else
            {
                Console.WriteLine(new string(repeatChar, current));
            }
        }
    }
    }
