    string x = "Hello";
    string y = new String("Hello".ToCharArray());
    Console.WriteLine(x == y); // True; uses overloaded operator
    object a = x;
    object b = y;
    Console.WriteLine(a == b); // False; uses default implementation
