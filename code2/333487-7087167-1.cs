    class Program
    {
        static void Main(string[] args)
        {
            string[] tmp = new string[] { "foo", "baa" };
            string foo, baa;
            tmp.Go(out foo, out baa);
            Console.WriteLine(foo);
            Console.WriteLine(baa);
            Console.ReadKey();
        }
    }
    public static class PHPList
    {
        public static void Go(this string[] soruce, out string p1, out string p2)
        {
            p1 = soruce[0] + "";
            p2 = soruce[1] + "";
        }
    }
