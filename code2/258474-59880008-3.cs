     class Program
     {
        public class ConsoleWindow : YourLibrary.ComponentModel.IClosable
        {
            public void Close()
            {
                Console.WriteLine("Closing area...");
            }
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.DoMain(args);
        }
        public void DoMain(string[] args)
        {
            var consoleWindow = new ConsoleWindow();
            var viewModel = new MyViewModel()
            viewModel.ButtonCommand.Execute(consoleWindow);
        }
     }
  
