class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            MyClass1 c2 = new MyClass1();
            var b = c is IInterface;
            Console.WriteLine(b); //False
            Console.WriteLine(c2 is IInterface); //True
            Console.ReadKey();
        }
    }
    class MyClass
    {
    }
    class MyClass1 : IInterface
    {
    }
    interface IInterface
    {
    }</code></pre>
