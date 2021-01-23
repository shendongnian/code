    public static class QueuedConsole
    {
        private static StringBuilder _sb = new StringBuilder();
        private static int _lineCount;
       
        public void WriteLine(string message)
        {
            _sb.AppendLine(message);
            ++_lineCount;
            if (_lineCount >= 10)
               WriteAll();
        }
        public void WriteAll()
        {
            Console.WriteLine(_sb.ToString());
            _lineCount = 0;
            _sb.Clear();
        }
    }
    QueuedConsole.WriteLine("This message will not be written directly, but with nine other entries to increase performance.");
    //after your operations, end with write all to get the last lines.
    QueuedConsole.WriteAll();
