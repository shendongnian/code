    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 = " + IsDefault(1));
            Console.WriteLine("0 = " + IsDefault(default(int)));
            Console.WriteLine("1.0 = " + IsDefault(1.0));
            Console.WriteLine("0.0 = " + IsDefault(default(double)));
            Console.WriteLine("Today = " + IsDefault(DateTime.Today));
            Console.WriteLine("1.1.1 = " + IsDefault(default(DateTime)));
            //Console.WriteLine(IsDefault(""));
            //Console.WriteLine(IsDefault(default(string)));
            Console.ReadKey();
        }
        static bool IsDefault(object boxedValueType)
        {
            if (boxedValueType == null) throw new ArgumentNullException("boxedValueType");
            var t = boxedValueType.GetType();
            if (!t.IsValueType) throw new ArgumentOutOfRangeException("boxedValueType");
            object def = Activator.CreateInstance(t);
            return boxedValueType.Equals(def);
        }
    }
