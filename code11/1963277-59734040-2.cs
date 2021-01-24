    class Program {
        static void Main(string[] args) {
            var p = new Program();
            Console.ReadLine();
            Console.WriteLine(p.GetType());
        }
        public Program() {
            Console.WriteLine("ctor");
        }
    }
