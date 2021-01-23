    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo();
            Iphone i1 = (Iphone)d;
            i1.Money();
            ((Ipen)i1).Price();
            Console.ReadKey();
        }
    }
