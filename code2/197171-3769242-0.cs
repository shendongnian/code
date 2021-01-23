    Action<string, List<string>> discoverFiles = null;
    
    discoverFiles = new Action<string, List<string>>((dir, list) =>
        {
            try
            {
                foreach (var subDir in Directory.GetDirectories(dir))
                    discoverFiles(string.Concat(subDir), list);
    
                foreach (var dllFile in Directory.GetFiles(dir, "*.dll"))
                {
                    var fileNameOnly = Path.GetFileName(dllFile);
                    if (!list.Contains(fileNameOnly))
                        list.Add(fileNameOnly);
                }
            }
            catch (IOException)
            {
                // decide what to do here
            }
        });
    
    // usage:
    var targetList = new List<string>();
    discoverFiles("c:\\MyDirectory", targetList);
    
    foreach (var item in targetList)
        Debug.WriteLine(item);
