    class Program
    {
        static void Main(string[] args)
        {
            double value = .5;
            var fv = string.Format("{0:0.0%}", value);
            Console.WriteLine(fv);
            Console.ReadLine();
        }
    }
