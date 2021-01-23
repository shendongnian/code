    interface IRenderable
    {
        string ViewName
        {
            get;
        }
    }
    
    public class Table : IRenderable
    {
        public string ViewName
        {
            get
            {
                return "Table";
            }
        }
    
        public List<Row> Rows { get; set; }
    }
    
    public class Row : IRenderable
    {
        public string ViewName
        {
            get
            {
                return "Row";
            }
        }
    
        public string Value { get; set; }
    }
