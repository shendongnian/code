    public abstract class Foo<T> where T :Foo<T> {
        public event Bar<T> Bar;
        public void Test ()
        {
            if (Bar != null)
            {
                Bar (this);
            }
        }
    }
    public class FooWorld : Foo<FooWorld> {
    }
    public delegate void Bar<T>(Foo<T> foo) where T : Foo<T>;
    class MainClass
    {
        public static void Main (string[] args)
        {
            FooWorld fw = new FooWorld ();
            fw.Bar += delegate(Foo<FooWorld> foo) {
                Console.WriteLine ("Bar response to {0}", foo);
            };
            fw.Test ();
        }
    }
