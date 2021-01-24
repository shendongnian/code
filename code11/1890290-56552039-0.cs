    public class Program
    {
       
        public static int MyDelegateMethod(string str) => str.Length;
        public static void Main(string[] args)
        {
            var test = new SomeClass(MyDelegateMethod);
            test.Test();
        }
    }
    public class SomeClass
    {
        Func<string, int> MyDelegateMethod;
        public SomeClass(Func<string, int> MyDelegateMethod) => this.MyDelegateMethod = MyDelegateMethod;
        public void Test() => Console.WriteLine(MyDelegateMethod("Test"));
    }
