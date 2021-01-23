    public abstract class ContentType
        {
            public string ContentName { get; set; }
            public string FolderName { get; set; }
            public bool RenameFile { get; set; }
            public bool HasMultiple { get; set; }
    
            public virtual string GetFileName()
            { 
                //Base GetFileName implementation
                return "filename";
            }
        }
