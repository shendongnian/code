    class Foo
    {
        public int i { get; set; }
     
        public static int Apply(Foo obj, Func<int, int, int> method, int j)
        {
            return method(j, obj.i);
        }
    
        public static int Multiply(int j, int i)
        {
            return i * j;
        }
        public static int Add(int j, int i)
        {
            return i + j;
        }
    }
    
    static void Main(string[] args)
    {
        var foo = new Foo { i = 7 };
        Console.Write("{0}\n", Foo.Apply(foo, Foo.Multiply, 5));
        Console.Write("{0}\n", Foo.Apply(foo, Foo.Add, 5));
        Console.ReadKey();
    }
