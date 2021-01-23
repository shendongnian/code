     bool f() {
        Console.WriteLine("f called");
        return false;
     }
     bool g() {
        Console.WriteLine("g called");
        return false;
     }
     static void Main() {
        bool result = f() && g(); // prints "f called"
        Console.WriteLine("------");
        result = f() & g(); // prints "f called" and "g called"
     }
