    public class UploadedFileDocument : DocumentType
    {
        public virtual string ContentType { get; set; }
    }
    public class ApplicationFormDocument : DocumentType
    {
    }
    public class UploadFileDocumentMap : 
                 SubclassMap<UploadedFileDocument>
    {
        public UploadFileDocumentMap()
        {
            GenerateMap();
        }
        void GenerateMap()
        {
            Map(x => x.ContentType);
        }
    }
    public class ApplicationFormDocumentMap : 
                 SubclassMap<ApplicationFormDocument>
    {
    }
