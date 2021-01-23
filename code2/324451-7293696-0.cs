    class PrintVariadic<T>
    {
        public T Value { get; set; }
        public void Print()
        {
            InnerPrint(Value);
        }
        static void InnerPrint<Tn>(Tn t)
        {
            var type = t.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Tuple<,>))
            {
                var i1 = type.GetProperty("Item1").GetValue(t, new object[]{});
                var i2 = type.GetProperty("Item2").GetValue(t, new object[]{ });
                InnerPrint(i1);
                InnerPrint(i2);
                return;
            }
            Console.WriteLine(t.GetType());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var v = new PrintVariadic<Tuple<
                int, Tuple<
                string, Tuple<
                double, 
                long>>>>();
            v.Value = Tuple.Create(
                1, Tuple.Create(
                "s", Tuple.Create(
                4.0, 
                4L)));
            v.Print();
            Console.ReadKey();
        }
    }
