    _fileClasses = GetFileClasses();
    
    // create a dictionary for fast lookup
    var changes = _fileClasses.Where(x => x.Filename != null && x.NewFilename != null)
                              .ToDictionary(x => x.Filename, x => x.NewFilename);
    
    // parallel the workloads
    Parallel.ForEach(_fileClasses, (item) =>
    {
       // iterate through the references
       for (var i = 0; i < item.FileReferences.Length; i++)
       {
          // check for updates
          if (changes.TryGetValue(item.FileReferences[i], out var value))
             item.FileReferences[i] = value;
       }
    });
