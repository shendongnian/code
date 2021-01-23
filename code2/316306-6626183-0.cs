        class Program {
        static void DigitRearranger()
        {
            string response = "";
            int num;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---------Welcome to the Digit Re-arranger!---------");
                Console.WriteLine("I take a positive number up to 10000, and find the highest number that can be made out of its digits.");
                Console.WriteLine("Instructions: Enter a number up to 10000, and see the results!");
                Console.ResetColor();
                Console.Write("Your Number: ");
                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Not a number.  Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                //todo:  reaarrange the number & print results
                /*Placeholder code for the moment*/
                Console.WriteLine(num);
                Console.Write("Do you want to exit? Yes/No: ");
                response = Console.ReadLine();
            
            } while (response.ToLower() != "yes");
        }
        //UI driver only in Main method:
        static void Main(){
            string response = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the ACSL Competition Program. Choose a program to begin:");
                Console.WriteLine("\n\t1\tDigit Re-arranger");
                Console.WriteLine("\tq\tQuit");
        
                Console.Write("\nProgram: ");
                response = Console.ReadLine();
                switch(response)
                {
                    case "1":
                        DigitRearranger();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Not a valid program.  Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            } while (response.ToLower() != "q");
            Console.ReadLine();
        }}
