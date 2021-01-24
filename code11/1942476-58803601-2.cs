    static void Main(string[] args)
    {
        int i, j;
        i = 1;
    
        int sum = 0;
        while (i <= 9)
        {
            for (j = 0; j <= i - 1; j++)
            {
                Console.Write(i);
                sum += i * (int)Math.Pow(10, j);
            }
    
            Console.WriteLine();
            i++;
        }
    
        Console.WriteLine("Sum: " + sum);
        Console.ReadLine();
    }
