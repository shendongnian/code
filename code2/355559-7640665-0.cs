     MyFileInfo
        {
            public FileInfo TheFileInfo;
            public string CustomProperty
            {
               get
               {
                   if(this.TheFileInfo != null)
                        return this.TheFileInfo.FileName + this.TheFileInfo.FullName;
                    return string.Empty;
               }
            }
        }
    
       
