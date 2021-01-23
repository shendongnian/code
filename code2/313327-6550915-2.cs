    public class ConcurrentConsole
    {
        private static BlockingCollection<string> output
            = new BlockingCollection<string>();
        public static Task CreateWriterTask(CancellationToken token)
        {
            return new Task(
                () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        string nextLine = output.Take(token);
                        Console.WriteLine(nextLine);
                    }
                },
                token);
        }
        public static void WriteLine(Func<string> writeLine)
        {
            output.Add(writeLine());
        }
    }
