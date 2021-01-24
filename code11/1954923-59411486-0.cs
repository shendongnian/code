                try
                {
                    if (!diSource.ToString().Contains("System Volume Information") && 
                      !diSource.ToString().ToUpper().Contains("$RECYCLE.BIN"))
                    {
                    
                        entries = Directory.GetFileSystemEntries(sourceDirectory, "*", 
                        SearchOption.AllDirectories);
                       
                    }
                }
    
                 catch (UnauthorizedAccessException ex)
                 {
                    //ok, so we are not allowed to dig into that directory. Move on.
                 }
