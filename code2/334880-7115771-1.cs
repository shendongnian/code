    public class A
    {
    }
    public class B : A
    {
    }
    public static class Extensions
    {
        /// Allows you to do:
        /// var whoop = new B();
        /// whoop.Foo();
        public static void Foo<T>(this T thing) where T : A
        {
            Console.WriteLine("Called from " + thing.GetType().Name);
        }
    }
