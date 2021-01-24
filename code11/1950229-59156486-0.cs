    class Program
    {
        private static List<int> numbers = new List<int>();
        private static int Prompt()
        {
            //1. Promt the user for input
            Console.Write("Please enter a number or 'ok' to end: ");
            var input = Console.ReadLine().ToLower();
            int number = 0;
            if (input.Equals("ok"))
            {
                //2. Do nothing and end the Program
            }
            else
            {
                //3. Ty to parse to int and append to the list
                if(int.TryParse(input, out number))
                {
                    //4. Add the number to the list (no more needed for sum but still if you want to maintain the order of numbers added :))
                    numbers.Add(number);                    
                }
                else
                {
                    //5. In case of junk input
                    Console.WriteLine("Invalid input.");
                }
                number += Prompt();
            }
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Total of the Inout Numbers: " + Prompt());
            Console.ReadKey();
        }
    }
