    class Program
    {
        public class Refferenced<T> where T : struct 
        {
            public T Value { get; set; }
        }
        static void Main(string[] args)
        {
            Refferenced<double> x = new Refferenced<double>();
            Refferenced<double> y = new Refferenced<double>();
            y.Value = 2;
            x = y;
            x.Value = 5;
            Console.WriteLine(x.Value);
            Console.WriteLine(y.Value);
            y.Value = 7;
            Console.WriteLine(x.Value);
            Console.WriteLine(y.Value);
            Console.ReadKey();
        }
