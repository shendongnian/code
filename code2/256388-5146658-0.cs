    public static class ConsoleHelper
    {
        public static void EnvironmentSafeWrite(string s)
        {
            s = Environment.NewLine == "\n" ? s : s.Replace("\n", Environment.NewLine);
            Console.Write(s);
        }
    }
