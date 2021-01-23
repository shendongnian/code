    double a = 1.0;
    double b = 1.0 / (1L << 53);
    double c = a;
    Console.WriteLine(a - b < c); // Prints True
    Console.WriteLine(a < b + c); // Prints False
