    Console.Write("Prime number finder, enter your number below:  ");
    int i, j, n = int.Parse(Console.ReadLine());
    bool isPrime = false;
    for (i = 2; i <= n; i++)
    {
        isPrime = true;
        for (j = 2; j < (i / 2); j++)
        {
            if (i % j == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            Console.WriteLine($"{i} Is a prime number.");
        }
    }
    if (!isPrime)
    {
        Console.WriteLine($"{n} Is not a prime number.");
    }
