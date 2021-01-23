    public class Example
    {
        public static void Generic<T>()
        {
            Console.WriteLine("The type of T is: {0}", typeof(T));
        }
    }
    
    class Program
    {
        static void Main()
        {
            var mi = typeof(Example).GetMethod("Generic");
            MethodInfo miConstructed = mi.MakeGenericMethod(typeof(string));
            miConstructed.Invoke(null, null);
        }
    }
