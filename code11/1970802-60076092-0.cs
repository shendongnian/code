     static void Main(string[] args)
        {
            Console.WriteLine("Please enter repeat time:");
            var counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Please enter your number:");
                var number = int.Parse(Console.ReadLine());
                Console.WriteLine($"{number} + 5 = {number +5}");
            }
            
            Console.ReadLine();
        }
