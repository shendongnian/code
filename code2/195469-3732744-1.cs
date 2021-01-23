    using System;
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            string userName;
            string line;
            int i = 0, totalCal = 0, cal = 1;
            Console.WriteLine("Welcome to the magical calorie counter!");
            Console.WriteLine();
            Console.Write("Enter in your name -> ");
            userName = Console.ReadLine();
            for (i = 0; i <= 10; i++)
            {
                Console.WriteLine("Hello {0}.....Let's add some calories!!", userName);
            }// end for loop
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter some Calories:<or 0 to quit>: ");
                line = Console.ReadLine().ToLower();
                if (line == "q" || line == "quit")
                {
                    break;
                }
                else if (!int.TryParse(line, cal))
                {
                    Console.WriteLine("Not a valid option. Please try again.");
                    continue;
                }
                Console.WriteLine("You entered {0}", cal);
                Console.WriteLine();
                totalCal += cal;
                Console.WriteLine();
                Console.WriteLine("-------------------So far you have a total of {0}------------------", totalCal);
                Console.WriteLine();
                Console.WriteLine();
            }// end of while 
        }// end of amin
    }
