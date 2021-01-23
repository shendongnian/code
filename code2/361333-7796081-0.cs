    class Program
    {
        static void Main(string[] args)
        {
            var fullList = "TextFile1.txt".ReadAsLines();
            var removeThese = "TextFile2.txt".ReadAsLines();
            //Change this line if you need to change the filter results.
            var cleanedList = fullList.Except(removeThese);
            cleanedList.WriteAsLinesTo("result.txt");
        }
    }
    public static class Tools
    {
        public static IEnumerable<string> ReadAsLines(this string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
        public static void WriteAsLinesTo(this IEnumerable<string> lines, string filename)
        {
            using (var writer = new StreamWriter(filename) { AutoFlush = true, })
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
