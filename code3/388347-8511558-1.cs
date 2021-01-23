    int[] first = new int[] { 1, 2, 3, 4, 5 };
    int[] second = new int[first.Length];
    Array.Copy( first, second, first.Length );
    
    first[0] = 10;
    
    // prints 10
    Console.WriteLine( first[0] );
    // prints 1
    Console.WriteLine( second[0] );
