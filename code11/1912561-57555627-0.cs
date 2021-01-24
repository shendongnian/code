    public class Rootobject
    {
        public Table[] tables { get; set; }
    }
    
    public class Table
    {
        public string name { get; set; }
        public Column[] columns { get; set; }
        public string[][] rows { get; set; }
    }
    
    public class Column
    {
        public string name { get; set; }
        public string type { get; set; }
    }
