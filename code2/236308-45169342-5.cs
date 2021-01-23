    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 obj;
            obj.foo();  //Use of unassigned local variable 'obj'
        }
    }
    public class MyClass1
    {
        internal void foo()
        {
            Console.WriteLine("hello from foo");
        }
    }
