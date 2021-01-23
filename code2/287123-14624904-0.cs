    // A simple class
    public class MyTag1
    {
    }
    // Another simple class
    public class MyTag2
    {
    }
    // Magic class used to differentiate between methods.
    public class Magic<T, Q>
        where Q : T
    {
    }
    // Extensions
    public static class Extensions
    {
        // Rainbows and pink unicorns happens here.
        public static T Test<T>(this T t, Magic<MyTag1, T> x = null)
            where T : MyTag1
        {
            Console.WriteLine("1:" + t.ToString());
            return t as T;
        }
        // More magic, other pink unicorns and rainbows.
        public static T Test<T>(this T t, Magic<MyTag2, T> x = null)
            where T : MyTag2
        {
            Console.WriteLine("2:" + t.ToString());
            return t as T;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTag1 t1 = new MyTag1();
            MyTag2 t2 = new MyTag2();
            Console.WriteLine(t1.Test().ToString());
            Console.WriteLine(t2.Test().ToString());
        }
    }
