            Console.Write("Enter the amount deposited: ");
            double principle = 0; 
            principle = double.Parse(Console.ReadLine());
            Console.Write("Enter number of years: ");
            int years = 0;
            years = int.Parse(Console.ReadLine());
            Console.Write("Enter the interest rate as a percentage of 1.0: ");
    
            double interest;
            interest = double.Parse(Console.ReadLine());
            double balance = 0;
            Console.WriteLine("Years \t Balance", years);
            for (int i = 0; i < years; i++)
            {
                balance = principle * Math.Pow((1 + interest), i);
                Console.WriteLine("{0} \t {1}", i, balance);
            }
