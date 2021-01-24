csharp
    public class ImportManager
    {        
        [Ignore]
        public string FileSeperator { get; set; }
        [Ignore]
        public string Filename { get; set; }
        public IEnumerable<T> ParseFile<T>() where T : class
        {
            using (var reader = new StreamReader(this.Filename))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = this.FileSeperator;
                csv.Configuration.HasHeaderRecord = true;
                var results = csv.GetRecords<T>().ToList();
                return results;
            }
        }
    }
