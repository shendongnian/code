    DirectoryEntry mimeMap = new DirectoryEntry("IIS://localhost/MimeMap")
    
    PropertyValueCollection collection = mimeMap.Properties["MimeMap"];
    
    MimeMapClass newMimeType = new MimeMapClass();
    newMimeType.Extension = ext;
    newMimeType.MimeType = mime;
    collection.Add(newMimeType);
    mimeMap.CommitChanges();
