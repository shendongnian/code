    class Program
    {
        static void Main(string[] args)
        {
            var fullList = "TextFile1.txt".ReadAsLines();
            var removeThese = "TextFile2.txt".ReadAsLines();
            //Change this line if you need to change the filter results.
            //Note: this assume you are wanting to remove results from the first 
            //      list when the entire record matches.  If you want to match on 
            //      only part of the list you will need to split/parse the records 
            //      and then filter your results.
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
