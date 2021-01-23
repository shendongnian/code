    [Serializable]   
    public class KeyValueCSV 
    {
        public string Key { get;set;}
        public List<string> CSVValues { get;set;}
    }
     var groups = 
           Result.GroupBy(res => res.ID)
           .Select(x => new KeyValueCSV() { 
                Key=x.key, 
                CSVValues= string.Join(",", x.ToList()) 
               }
           );
