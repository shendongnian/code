    double a = 1L << 53;
    double b = 1;
    double c = a;
    Console.WriteLine(a - b < c); // Prints True
    Console.WriteLine(a < b + c); // Prints False
