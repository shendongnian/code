    public class Example
    {
        public static void Main()
        {
            string pattern = @"\s*(.+?)\s+[A-Z]+,";
            string input = @"CREATE TABLE Tablex(
      column1 INT,
      column2 TEXT,
      column3 INT,
      column4 INT,
    )
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
