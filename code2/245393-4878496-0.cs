    class Program {
        static void Main(string[] args) {
            var calc = new System.Data.DataTable();
            Console.WriteLine(calc.Compute("(123/2*15+22)", ""));
            Console.ReadLine();
        }
    }
