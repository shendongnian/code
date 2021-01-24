    class Program
    {
        static void Main(string[] args)
        {
            var foo = Base.Create<Foo>();
            var bar = Base.Create<Bar>();
            Console.WriteLine(foo.GetType().Name);
            Console.WriteLine(bar.GetType().Name);
            Console.ReadKey();
        }
    }
    public abstract class Base
    {
        public static T Create<T>() where T : Base
        {
            return Activator.CreateInstance<T>();
        }
    }
    public class Bar : Base
    {
    }
    public class Foo : Base
    {
    }
