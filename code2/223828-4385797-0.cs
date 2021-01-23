    interface IFileSystemItem
    {
        string Name {get; set;}
    
        // folder for files, parent folder for folders, null for root folders.
        IFileSystemItem Parent {get;set;}
    
        DateTime CreatedAt {get;set;}
    
        DateTime ModifiedAt {get;set;}
    
        ISecurityInfo SecurityInfo {get;set;}
    }
