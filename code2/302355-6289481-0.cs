    public class Update
    {
        // ... ?
    }
    public class FileUpdate : Update
    {
        public virtual string Name { get; set; }
        public virtual string DownloadUri { get; set; }
        public virtual bool IsTickMarked { get; set; }
    }
    public class ApiFileUpdate : FileUpdate
    {
        // ...
    }
    public class BookmarkFileUpdate : FileUpdate
    {
        // ...
    }
