    class Program
    {
        static void Main(string[] args)
        {
        
            int doNum;
            const double tax = 1.13;
            double total = 0;
            const double cost1 = 1.00;
            const double cost2 = 0.90;
            const double cost3 = 0.75;
            const double covChrg = 0.25;
            {
                Console.WriteLine("Hi, can I get your name for your order?");
                string custLastName = Console.ReadLine();
                Console.WriteLine("Hello, {0} welcome to Rich Hortons!", custLastName);
                //Asking for user input
                Console.WriteLine("How many donuts would you like to order?");
                
                //Validating input using the TryParse method within a while loop
                while (!int.TryParse(Console.ReadLine(), out doNum))
                {
                    //Letting the user know that an invalid input was detected.
                    Console.WriteLine("That was invalid. Enter a valid quantity ");
                }
               
                
                if (doNum > 0 && doNum <= 7)
                {
                    total = cost1 * doNum * tax + covChrg;
                }
                else if (doNum > 7 && doNum < 12)
                {
                    total = (cost2 * doNum)* tax + covChrg; 
                }
                else if (doNum >= 12 && doNum < 15)
                {
                    total = cost2 * doNum + covChrg;
                }
                else if (doNum >= 15)
                {
                    total = cost3 * doNum + covChrg;
                }
                else
                {
                    Console.WriteLine("Invalid Order Amount");
                }
               
            }
            
        
            //Outputting the result to the user.
            Console.WriteLine("Your total cost is {0} ", total);
            
            //We are using the Console.ReadLine() below to ensure that the 
            Console.ReadLine();
        }
    }
}
