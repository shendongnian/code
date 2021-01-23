              public void ExtractFiles(string fileName, string outputDirectory)
              {
                    using (ZipFile zip1 = ZipFile.Read(fileName))
                    {
                        var selection = (from e in zip1.Entries
                                         where (e.FileName).StartsWith("CSS/")
                                         select e);
                        
                        
                        Directory.CreateDirectory(outputDirectory);
        
                        foreach (var e in selection)
                        {                            
                            e.Extract(outputDirectory);        
                        }
                    }
             }
