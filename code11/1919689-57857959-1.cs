    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            List<CSVData> records;
    
            using (var reader = new StreamReader("test.csv"))
            using (var csv = new CsvReader(reader))
            {
                records = csv.GetRecords<CSVData>().ToList();
            }
    
            foreach (var r in records)
            {
                Console.WriteLine($"Time:{r.Time} Value1:{r.Value1} Value2:{r.Value2} Value3:{r.Value3}");
            }
        }
    }
