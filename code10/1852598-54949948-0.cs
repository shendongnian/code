    BigInteger c = new BigInteger(0);
    int a = 100;
    c = a * (a - 1);
    for (int i = a - 2; i >= 1; i--)
    {
        c = c * i;
    }
    Console.WriteLine(c);
    Console.ReadLine();
