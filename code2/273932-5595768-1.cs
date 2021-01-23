    //Console.exe
    namespace Console
    {
        using Library;
        class Program
        {
            static void Main(string[] args)
            {
                //var foo = new Foo(); Compilation error
    
                var foo = Factory.CreateFoo();
                foo.DoSomething();
                System.Console.ReadLine();
            }
        }
    }
