    public class Program
    {
       
        public static int MyDelegateMethod(string str) => str.Length;
        public static void Main(string[] args)
        {
            var test = new SomeClass<string, int>(MyDelegateMethod);
            test.Test("Test");
        }
    }
    public class SomeClass<TIn, TOut>
    {
        Func<TIn, TOut> MyDelegateMethod;
        public SomeClass(Func<TIn, TOut> MyDelegateMethod) => this.MyDelegateMethod = MyDelegateMethod;
        public void Test(TIn input) => Console.WriteLine(MyDelegateMethod(input));
    }
