    public interface IDocumentValidator
    {
        bool IsValid(Document document);
    }
    
    public class DocAValidator : IValidator
    {
        public bool IsValid(Document document)
        {
            // specific implementation for doc A
        }
    }
    public class DocBValidator : IValidator
    {
        public bool IsValid(Document document)
        {
            // specific implementation for doc B
        }
    }
