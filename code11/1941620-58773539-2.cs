    public class DocumentBase
    {
        public void WhereEquals() { }
    }
    public class DocumentQuery : DocumentBase
    {
        // Other stuff
    }
    public class MultiDocumentQuery : DocumentBase
    {
        // Other stuff
    }
    public class DocumentQueryObject
    {
        public int NodeID { get; set; }
        public int DocumentID { get; set; }
    }
