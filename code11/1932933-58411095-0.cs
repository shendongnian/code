        static void Main(string[] args)
        {
            //get input from user
            Console.WriteLine("Please enter your integer: ");
            int a = int.Parse(Console.ReadLine());
            //enumerate factors
            var factors = Enumerable.Range(1, a)
                .Where(i => a % i == 0).ToArray();
            
            //join for nicely printed output
            Console.Write(string.Join(" and ", factors));
            Console.ReadLine();
        }
