    public class DataGridColumnData<TSearch, TResult> : IDataGridColumnData
    {
        public TSearch SearchColumn { get; set; }
        public static TResult ResultColumn { get; set; }
        public object SearchColumnAsObject
        {
            get { return SearchColumn; }
            set { SearchColumn = (TSearch)value; }
        }
        public object ResultColumnAsObject
        {
            get { return ResultColumn; }
            set { ResultColumn = (TResult)value; }
        }
    }
        
