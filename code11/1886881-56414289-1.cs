    // Flexible strategy you can tinker with and change without affecting the main program.
    public class LineSelectionStrategy
    {
        public bool LineMeetsCondition(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;
            return line.StartsWith("start"); // Add your condition here
        }
    }
    // Represents a command in a text file comprised of an execution function
    // and a command / app / action to run with that function.
    public class TextCommand
    {
        public string Function { get; }
        public string Action { get; }
        private readonly char[] _commandSeparators = { ' '};
        public TextCommand(string textLine)
        {
            var elements = textLine.Split(_commandSeparators, StringSplitOptions.RemoveEmptyEntries);
            Function = elements.FirstOrDefault();
            Action = elements.LastOrDefault();
        }
    }
