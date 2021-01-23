    static void Main()
    {
        Foo foo = new Foo();
        Foo.DoSomething();
        foo.DoSomethingElse();
    }
    
    public class Foo
    {
        public static void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    
        public void DoSomethingElse()
        {
            Console.WriteLine("DoSomethingElse");
        }
    }
