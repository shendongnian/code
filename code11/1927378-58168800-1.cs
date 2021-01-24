    class Program
    {
        static void Main(string[] args)
        {
            var listA = new List<A>
            {
                new A(1001, true, 1.001f, "A1"),
                new A(1002, true, 1.002f, "A2"),
                new A(1003, false, 1.003f, "A1"),
                new A(1004, false, 1.004f, "A4")
            };
            var listB = new List<B>
            {
                new B(1001, true, 1.001f, "B1", 2.5),
                new B(1002, false, 1.002f, "B2", 2.8),
                new B(1003, true, 1.003f, "B3", 2.9),
                new B(1004, false, 1.004f, "B4", 2.9)
            };
            var common = Enumerable.Intersect(listA, listB, new CommonComparer()).OfType<ICommon>();
            Console.WriteLine($"{"SomeInt",-8} {"Bool",-6} {"SomeFloat",-10}");
            foreach (var item in common)
            {
                Console.WriteLine($"{item.SomeInt,-8} {item.SomeBool,-6} {item.SomeFloat,-10}");
            }
            //SomeInt  Bool   SomeFloat
            //1001     True   1.001
            //1004     False  1.004
        }
    }
