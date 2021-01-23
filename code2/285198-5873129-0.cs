    int a, b;
    Console.WriteLine("Please enter your integer: ");
    a = int.Parse(Console.ReadLine());
    for (b = 2; a > 1; b++)
        if (a % b == 0)
        {
            int x = 0;
            while (a % b == 0)
            {
                a /= b;
                x++;
            }
            Console.WriteLine("{0} is a prime factor {1} times!", b, x);
        }
    Console.WriteLine("Th-Th-Th-Th-Th-... That's all, folks!");
