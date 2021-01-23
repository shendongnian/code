    public class GridFilter
    {
        public string groupOp { get; set; }
        public GridRule[] rules { get; set; }
    }
    public class GridRule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }
    public class GridSettings
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public GridFilter Where { get; set; }
    }
