        static void Main(string[] args)
        {
            int i, n, sum = 0;
            double avg;
    
            Console.Write("Enter up to 10 numbers \n");
            Console.Write("-------------------\n\n");
    
            for (i = 1; i <= 10; i++) 
            {
                Console.Write("Number {0}:", i);
                n = Convert.ToInt32(Console.ReadLine());
                sum += n;
    
                // Changed the i to n
                if (n == 0)
                {
                    break;
                }
            }
    
            avg = sum / 10.0;
            Console.Write("Sum: {0} \nAverage: {1}", sum, avg);
    
            Console.Write("\n\nPress any key to exit..");
            Console.ReadKey();
    }
