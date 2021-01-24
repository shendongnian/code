    class Program
    {
        static async Task Main(string[] args)
        {
            var timeout = 10;
            var textToWrite = "Hello World!";
            bool isTimeIsUp = false;
            bool returnPressed = false;
            StringBuilder enteredText = new StringBuilder();
            Console.WriteLine($"You have {timeout} seconds to write: '{textToWrite}'");
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!returnPressed)
            {
                while (!isTimeIsUp && !Console.KeyAvailable)
                {
                    isTimeIsUp = stopwatch.Elapsed.Seconds >= timeout;
                }
                if (isTimeIsUp) break;
                var ch = Console.ReadKey();
                returnPressed = ch.Key == ConsoleKey.Enter;
                if (!returnPressed)
                {
                    enteredText.Append(ch.KeyChar);
                }
            }
            if (isTimeIsUp || enteredText.ToString() != textToWrite)
            {
                Console.WriteLine($"\nFailure!");
            }
            else
            {
                Console.WriteLine($"\nSuccess!");
            }
        }
    }
