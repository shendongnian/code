    static class ExtensionMethods
    {
        public static IEnumerable<string> EnumerateLines(this TextReader reader)
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
    ...
    var regex = new Regex(..., RegexOptions.Compiled);
    using (var reader = new StreamReader(fileName))
    {
        var specialLines =
            reader.EnumerateLines()
                  .Where(line => regex.IsMatch(line))
                  .Aggregate(new StringBuilder(),
                             (sb, line) => sb.AppendLine(line));
    }
