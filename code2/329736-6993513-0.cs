    string x = new StringBuilder("hello").ToString();
    string y = new StringBuilder("hello").ToString();
    Console.WriteLine(Object.Equals(x, y)); // True
    Console.WriteLine(Object.ReferenceEquals(x, y)); // False
    Console.WriteLine(x == y); // True due to overloading
