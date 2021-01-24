    public class ImportObject
    {
        public List<string> StringListNull { get; set; }
        public List<string> StringListEmpty { get; set; }
        public List<string> StringListPopulated { get; set; }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var line = string.Empty;
            while (!string.IsNullOrWhiteSpace((line = Console.ReadLine())))
            {
                sb.AppendLine(line);
            }
            var json = sb.ToString().Trim();
            var inputObj = JsonConvert.DeserializeObject<ImportObject>(json);
            Console.WriteLine();
        }
    }
