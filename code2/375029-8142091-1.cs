    class Program
    {
        static void Main(string[] args)
        {
            InvokeTest(new Action(Program.Crap));
            var p = new Program();
            Console.WriteLine(InvokeTest(new Func<int, int>(p.Pipi), 3));
            Console.ReadLine();
        }
        static object InvokeTest(Delegate d, params object[] args)
        {
            d.Method.GetCustomAttributes(typeof(CocoAttribute), false);
            return d.DynamicInvoke(args);
        }
        [Coco]
        static void Crap()
        {
            Console.WriteLine("Caca");
        }
        [Coco]
        int Pipi(int a)
        {
            Console.WriteLine("Pipi: " + a);
            return a * 2;
        }
    }
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class CocoAttribute : Attribute
    {
        // This is a positional argument
        public CocoAttribute()
        {
            Console.WriteLine("Coco");
        }
    }
