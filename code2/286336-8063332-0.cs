      public void MyExtractZip(string FileName,string Password)
            {
                string ExtractLocation = string.Empty;
                using (ZipFile zip = ZipFile.Read(FileName))
                {
                    // here, we extract every entry, but we could extract conditionally
                    // based on entry name, size, date, checkbox status, etc. 
                    string ArchiveName =Path.GetFileNameWithoutExtension(FileName);
                    Console.WriteLine("[1] Extract Here [2] Extract too [3] Extract to "+ArchiveName);
                    Console.WriteLine("\n");
                    Console.Write("Select your option :: \t");
                     string entry = Console.ReadLine();
                     int n = int.Parse(entry);
    
                    string Location =string.Empty;
                    if (n == 2)
                    {
                        Console.Write("Enter the Location ::" );
                        Location = Console.ReadLine();
                       
                    }
                    Console.Write("\n");
                    switch (n)
                    {
                        case 1:
                            ExtractLocation=Path.GetDirectoryName(FileName);
                            break;
                        case 2:
                            ExtractLocation = Location + "\\"; 
                            break;
                        case 3:
                            ExtractLocation = Path.GetDirectoryName(FileName) + "\\"+Path.GetFileNameWithoutExtension(FileName);
                            break;
                    }
                    zip.Password = Password;
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(ExtractLocation, ExtractExistingFileAction.OverwriteSilently);
                    }
    
                }
            }
