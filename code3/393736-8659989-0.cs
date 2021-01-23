    interface ITableRow
    {
    
        string RowTitle { get; set; }
        string RowSubTitle { get; set; }
    
    }
    
    
    class TableRow<T> : ITableRow
    {
    
        public TableRow(string rowTitle, string rowSubtitle, T dataObject)
        {
            // fill the properties with values here
        }
    
        public string RowTitle { get; set; }
        public string RowSubTitle { get; set; }
        public T DataObject { get; set; }
    }
