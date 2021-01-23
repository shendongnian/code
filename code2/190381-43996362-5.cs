    class myrenderer : PrindListConsoleRender<int> {
        public String Render(int input) {
            return "Number: " + input;
        }
    }
    class Program {
        static void Main(string[] args) {
            var list = new List<int> { 1, 2, 3 };
            var printer = new PrintListToConsole<int>();
            printer.SetRenderer(new myrenderer());
            printer.PrintToConsole(list);
            string result = Console.ReadLine();   
        }   
    }
    
    
