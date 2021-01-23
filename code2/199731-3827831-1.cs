    class Program
    {
    static void Main(string[] args)
    {
    string y =string.Empty;
    y="hello";
    
    Program p = new Program();
    p.foo( y);
    Console.WriteLine(y );
    }
    
    void foo(string sb)
    {
    sb +="anish:";
    }
    }
