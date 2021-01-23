    class Program {
        static void Main(string[] args) {
            var list = new Array[1, 2, 3];
            var printer = new PrintListToConsole<int>();
            printer.SetRenderFunc((o) => "Number:" + o);
            printer.Print();
            string result = Console.ReadLine();
        }
    }
