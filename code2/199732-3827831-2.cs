    class Program
    {
    static void Main(string[] args)
    {
    string y ="";
    y="hello";
    
    Program p = new Program();
    p.foo(ref y);
    Console.WriteLine(y );
    }
    void foo(ref string sb)
    {
    sb="anish:";
    }
    }
