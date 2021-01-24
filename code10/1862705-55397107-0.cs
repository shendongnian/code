    class RowData
    {
        public string Agent {get; set}
        public DateTime Date {get; set;}
        public int Amount {get; set;}
    }
    IEnumerable<RowData> tableData = ...
