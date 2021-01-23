    class Program
    {
        static void Main(string[] args)
        {
            Foo t = new Foo();
            // Line numbering for convenience
            t.MyMethod<bool>(true);                     // #1
            t.MyMethod<bool>(new bool[] { true });      // #2
            t.MyMethod<bool[]>(new bool[] { true });    // #3
        }
    }
    public class Foo
    {
        public void MyMethod<T>(T value)
        {
            Console.WriteLine("Single element method called");
        }
        public void MyMethod<T>(T[] array)
        {
            Console.WriteLine("Array method called");
        }
    }
