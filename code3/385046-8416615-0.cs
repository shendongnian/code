    class Example
    {
        public static void Generic<T>()
        {
            System.Console.WriteLine("\r\nHere it is: {0}", "DONE");
        }
        static void Main()
        {
            var mi = typeof (Example).GetMethod("Generic");
            mi.MakeGenericMethod(typeof(int)).Invoke(null, null);
        }
    }
