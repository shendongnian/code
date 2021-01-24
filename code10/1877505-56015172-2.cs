    double a = 17.125 / 3.0;
    double b = 17.12499999999999 / 3.0;
    Console.WriteLine(a);
    Console.WriteLine(b);
    Console.WriteLine(a.ToString("G17"));
    Console.WriteLine(b.ToString("G17"));
    Console.WriteLine(a == b);
    Console.WriteLine(Convert.ToString(*(long*)&a, 2));
    Console.WriteLine(Convert.ToString(*(*)&b, 2));
