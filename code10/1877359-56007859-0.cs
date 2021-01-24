    public class Weather {
        public string Outlook {get;set;}
        public string Temperature{get;set;}
        public string Humidity{get;set;}
        public string Wind{get;set;}
        public string Decision{get;set;}
    }
    void Main()
    {
        var records = new List<Weather>();
        using (var reader = new StreamReader("path\\to\\file.csv"))
        using (var csv = new CsvReader(reader))
        {
            var records = csv.GetRecords<Weather>();
        }
    }
    
