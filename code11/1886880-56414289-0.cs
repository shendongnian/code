    class Program
    {
        private static LineSelectionStrategy _lineSelectionStrategy;
        private static string _pathToFile;
        static void Main(string[] args)
        {
            _lineSelectionStrategy = new LineSelectionStrategy();
            // You can later define this in the args if using a console app if you want.
            _pathToFile = "Define Path here";
            var relativeCommands = ReadTextFileWithStrategy();
            // If you want to strongly type these, you can then go on to do something like this...
            IEnumerable<TextCommand> commands = relativeCommands.Select(cmdLine => new TextCommand(cmdLine));
            // Do stuff with your 'commands'
        }
        // Clean, simple, light-weight text reader
        static IEnumerable<string> ReadTextFileWithStrategy()
        {
            List<string> results = new List<string>();
            using (var reader = new StreamReader(_pathToFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (_lineSelectionStrategy.LineMeetsCondition(line))
                        results.Add(line);
                }
            }
            return results;
        }
    }
