    /// <summary>Simple base class. Can also be an interface, for example.</summary>
    public abstract class MyBase1
    {
    }
    /// <summary>Simple base class. Can also be an interface, for example.</summary>
    public abstract class MyBase2
    {
    }
    /// <summary>Concrete class 1.</summary>
    public class MyClass1 :
        MyBase1
    {
    }
    /// <summary>Concrete class 2.</summary>
    public class MyClass2 :
        MyBase2
    {
    }
    /// <summary>Special magic class that can be used to differentiate generic extension methods.</summary>
    public class Magic<TBase, TInherited>
        where TInherited : TBase
    {
        private Magic()
        {
        }
    }
    // Extensions
    public static class Extensions
    {
        // Rainbows and pink unicorns happens here.
        public static T Test<T>(this T t, Magic<MyBase1, T> x = null)
            where T : MyBase1
        {
            Console.Write("1:" + t.ToString() + " ");
            return t;
        }
        // More magic, other pink unicorns and rainbows.
        public static T Test<T>(this T t, Magic<MyBase2, T> x = null)
            where T : MyBase2
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
        }
    }
