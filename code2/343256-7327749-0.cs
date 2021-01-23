    class Program {
        static void Main(string[] args) {
            var stuff = from i in new double[] { 1, 2, 3 }
                        select new {
                            Value = (int) i,
                        };
            var sum = stuff.Sum( s => s.Value);
            Console.WriteLine(sum);
        }
    }
