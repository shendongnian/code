    class Program {
        static void Main(string[] args) {
            var list = new List<int> { 1, 2, 3 }; // should be a list as the method signature expects
            var printer = new PrintListToConsole<int>();
            printer.SetRenderFunc((o) => "Number:" + o);
            printer.Print(list); 
            string result = Console.ReadLine();
        }
    }
