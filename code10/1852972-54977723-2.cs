    public class DocAValidator : CommonDocumentValidator
    {
        public override bool IsValid(Document document)
        {
            if(!base.IsValid(document)) return false;
            // specific implementation for doc A
        }
    }
