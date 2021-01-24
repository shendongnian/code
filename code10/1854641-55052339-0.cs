    public class Column
    {
        public int BoardID { get; set; }
        public int ID { get; set; }
        public List<Row> Rows { get; set; }
    }
    
    public class Row
    {
        public int BoardID { get; set; }
        public int ColumnID { get; set; }
        public int ID { get; set; }
        public object Value { get; set; }
    }
    
    public class Board
    {
        public int ID { get; set; }
        public List<Column> Columns { get; set; }
    }
