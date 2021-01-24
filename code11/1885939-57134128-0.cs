       internal class Program
    {
        private static Line CreateLineFromString(string line)
        {
            string[] array = line.Split(';');
            return new Line
            {
                DateTime = Convert.ToDateTime(array[0],CultureInfo.InvariantCulture),
                Value1 = array[1],
                Value2 = array[2]
            };
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IEnumerable<Line> lines = ReadLines().ToList();
            var startDate = new DateTime(2019, 1, 1);
            var endDate = new DateTime(2019, 6, 30);
            foreach (Line line in lines.Where(line => line.DateTime >= startDate && line.DateTime <= endDate)) line.Value1 = "New Value";
            SaveLines(lines);
        }
        private static IEnumerable<Line> ReadLines()
        {
            using (var reader = new StreamReader("d:\\TextFile1.txt"))
            {
                string stringLine;
                while ((stringLine = reader.ReadLine()) != null)
                    if (stringLine != string.Empty)
                        yield return CreateLineFromString(stringLine);
            }
        }
        private static void SaveLines(IEnumerable<Line> lines)
        {
            using (var writer = new StreamWriter("d:\\TextFile1.txt",false))
            {
                foreach (Line line in lines) writer.WriteLine(line.ToString());
            }
        }
    }
    public class Line
    {
        public DateTime DateTime { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public override string ToString()
        {
            return $"{DateTime.ToString(CultureInfo.InvariantCulture)};{Value1};{Value2}";
        }
    }
