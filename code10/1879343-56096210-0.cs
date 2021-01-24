    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
    void Main()
    {
        using (var reader = new StreamReader("path\\to\\file.csv"))
        using (var csv = new CsvReader(reader))
        {
            var records = csv.GetRecords<Foo>();
        }
    }
