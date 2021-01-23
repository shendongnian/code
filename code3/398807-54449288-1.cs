    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Write test string: ");
            var test = ConsoleOutput.ReadLineOrKey();
            if (test.IsKey())
                Console.WriteLine(test.KeyName);
            else
                Console.WriteLine($"Output string: {test.OutputString}");
            Console.Read();
        }
    }
