    [Serializable]   
    public class KeyValueCSV 
    {
        public Key { get;set;}
        public CSVValues { get;set;}
    }
     var groups = 
           Result.GroupBy(res => res.ID)
           .Select(x => new KeyValueCSV() { 
                Key=x.key, 
                CSVValues= string.Join(",", x.ToList()) 
               }
           );
