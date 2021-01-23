    class Program
    {
        static void Main(string[] args)
        {
            PassInFoo( new Foo { Bar = false } );
        }
        public class Foo
        {
            public bool Bar = true;
        }
        
        public static void PassInFoo(Foo obj)
        {
            Console.WriteLine(obj.Bar.ToString());
            Console.ReadLine();
        }
    }
