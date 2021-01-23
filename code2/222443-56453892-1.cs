    // ~4s
    //
    List<string> files = Directory.EnumerateFileSystemEntries(directory, "*", SearchOption.AllDirectories)
        .ToList();
      
    // ~0s
    // 
    Dictionary<string, FileInfo> fileMap = files.Select(file => new
    {
        file,
        info = new FileInfo(file)
    })
    .ToDictionary(f => f.file, f => f.info);
        
    // ~10s
    //
    Int64 totalSize = fileMap.Where(kv => kv.Value != null)
        .AsParallel() // ~50s w/o this 
        .Select(kv =>
        {
            try
            {
                return kv.Value.Length;
            }
            catch (FileNotFoundException)  // a transient file or directory
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            return 0;
        })
        .Sum();
    
