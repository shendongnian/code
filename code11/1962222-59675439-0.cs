    public interface IBaseDocument
    {
        string Name { get; set; }
        DateTime Date { get; set; }
    }
    public interface IDocumentWithRows<T>
    {
        List<T> Rows { get; set; }
    }
    public class DocumentTypeOne: IBaseDocument, IDocumentWithRows<RowTypeOne>
    {
        string IBaseDocument.Name { get; set; }
        DateTime IBaseDocument.Date { get; set; }
        List<RowTypeOne> IDocumentWithRows<RowTypeOne>.Rows { get; set; }
    }
    public class DocumentProcessor
    {
        public void ProcessDocument(IBaseDocument doc)
        {
            switch (doc)
            {
                case DocumentTypeOne docTypeOne:
                    ProcessDocumentTypeOne(docTypeOne);
                    break;
                case DocumentTypeTwo docTypeTwo:
                    ProcessDocumentTypeTwo(docTypeTwo);
                    break;
            }
        }
    }
