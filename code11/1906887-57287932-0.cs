    class Program
    {
        static void Main(string[] args)
        {
            string[] prefixes = { "0.", "1.", "2.", "3.", "4.", "5.", "6.", "7.", "8.", "9." };
            var result = Directory.GetFiles(dir, filter).Select(s => prefixes.Contains(s.Substring(0, 2)) ? "0" + s : s).ToList();
        }
    }
