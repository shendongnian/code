    class Program
    {
    static void Main(string[] args)
    {
    StringBuilder y =new StringBuilder();
    y.Append("hello");
    
    Program p = new Program();
    p.foo( y);
    Console.WriteLine(y );
    }
    
    void foo(StringBuilder sb)
    {
    sb .Append("anish:");
    }
    }
