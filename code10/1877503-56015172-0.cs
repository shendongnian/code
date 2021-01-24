    double a = 17.125 / 3.0;
    double b = 17.12499999999999 / 3.0;
    Console.WriteLine(a.ToString("G17"));              // 5.708333333333333
    Console.WriteLine(b.ToString("G17"));              // 5.7083333333333295
    Console.WriteLine(a == b);                         // False
    Console.WriteLine(Convert.ToString(*(int*)&a, 2)); // 1010101010101010101010101010101
    Console.WriteLine(Convert.ToString(*(int*)&b, 2)); // 1010101010101010101010101010001
