    public static void Main(string[] args)
    {
        int n, i, m = 0, flag = 0;
        Console.Write("Prime number finder, enter your number below:  ");
        n = int.Parse(Console.ReadLine());
        m = n / 2;
        for (i = 2; i <= m; i++)
        {
            if (n % i == 0)
            {
                Console.Write("Is not a prime number.");
                flag = 1;
                break;
            }
    
            //Start added code
            bool flagPrime = true;
            for (int x = 2; x <= i; x++)
            {
                if (i % x == 0)
                    flagPrime = false;
            }
            if (flagPrime)
                Console.WriteLine(i);
            //End added code
        }
    
        if (flag == 0)
            Console.Write("Is a prime number.");
    }
