    interface IRowContent 
    {
        bool SupportsOtherChildren{ get; }
        ...
    }
    
    class ImageContent : IRowContent
    {
        public bool SupportsOtherChildren
        {
            get { return false; }
        }
    }
    class Column : IRowContent
    {
        public bool SupportsOtherChildren
        {
            get { return true; }
        }
    }
