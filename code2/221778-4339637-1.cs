    public class MyClass
    {
        public static class C&lt;T>
        {
            public static Func&lt;IList&lt;T>, T> SelectElement;
        }
        public int Test(IList&lt;int> list)
        {
            return C&lt;int>.SelectElement(list);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            MyClass.C&lt;char>.SelectElement = xs => xs.First();
            MyClass.C&lt;int>.SelectElement = xs => xs.First();
            var list = new List&lt;int>(new int[] { 1, 2, 3 });
            var c = new MyClass();
            var v = c.Test(list);
            Console.WriteLine(v);
        }
    }
