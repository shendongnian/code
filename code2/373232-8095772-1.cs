    public static string GetMimeTypeFromExtension(string extension)
    {
        using (DirectoryEntry mimeMap = 
               new DirectoryEntry("IIS://Localhost/MimeMap"))
        {
            PropertyValueCollection propValues = mimeMap.Properties["MimeMap"];
    
            foreach (object value in propValues)
            {
                    IISOle.IISMimeType mimeType = (IISOle.IISMimeType)value;
    
                    if (extension == mimeType.Extension)
                    {
                            return mimeType.MimeType;
                    }
            }
    
            return null;
    
        }
    }
