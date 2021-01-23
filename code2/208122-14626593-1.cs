    /// <summary>Special magic class that can be used to differentiate generic extension methods.</summary>
    public class MagicValueType<TBase>
        where TBase : struct
    {
    }
    /// <summary>Special magic class that can be used to differentiate generic extension methods.</summary>
    public class MagicRefType<TBase>
        where TBase : class
    {
    }
	
    struct MyClass1
    {
    }
    class MyClass2
    {
    }
    // Extensions
    public static class Extensions
    {
        // Rainbows and pink unicorns happens here.
        public static T Test<T>(this T t, MagicRefType<T> x = null)
            where T : class
        {
            Console.Write("1:" + t.ToString() + " ");
            return t;
        }
        // More magic, other pink unicorns and rainbows.
        public static T Test<T>(this T t, MagicValueType<T> x = null)
            where T : struct
        {
            Console.Write("2:" + t.ToString() + " ");
            return t;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 t1 = new MyClass1();
            MyClass2 t2 = new MyClass2();
            MyClass1 t1result = t1.Test();
            Console.WriteLine(t1result.ToString());
            MyClass2 t2result = t2.Test();
            Console.WriteLine(t2result.ToString());
            Console.ReadLine();
        }
    }
