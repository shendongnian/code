    public class Column
    {
        public string name { get; set; }
        public string type { get; set; }
    }
    
    public class Table
    {
        public string name { get; set; }
        public List<Column> columns { get; set; }
        public List<List<string>> rows { get; set; }
    }
    
    public class RootObject
    {
        public List<Table> tables { get; set; }
    }
