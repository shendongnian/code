      private void RecursivedMefPluginLoader(AggregateCatalog catalog, string path)
            {
                Queue<string> directories = new Queue<string>();
                directories.Enqueue(path);
                while (directories.Count > 0)
                {
                    var directory = directories.Dequeue();
                    //Load plugins in this folder
                    var directoryCatalog = new DirectoryCatalog(directory);
                    catalog.Catalogs.Add(directoryCatalog);
    
                    //Add subDirectories to the queue
                    var subDirectories = Directory.GetDirectories(directory);
                    foreach (string subDirectory in subDirectories)
                    {
                        directories.Enqueue(subDirectory);
                    }
                }
            }
