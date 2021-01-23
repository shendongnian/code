    private void ListAllDirectories(string root)
    {
        DirectoryInfo dr = new DirectoryInfo(root);
                    Console.WriteLine(dr.FullName);
                    var directories = dr.GetDirectories();
                    foreach (var directory in directories)
                    {
                        try
                        {
                            ListAllDirectories(directory.FullName);
        
                        }
        
                        catch
                        {
                            continue;
                        }
        
                    }
    }
