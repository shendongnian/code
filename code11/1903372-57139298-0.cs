    var sourceFiles = Directory.GetFiles("*.zip");
    foreach (var sourceFile in sourceFiles)
    {
        var tempFilename = sourceFile + ".processing";
        try  
        {
            if (File.Exists(sourceFile))
            {                  
                 File.Move(sourceFile, tempFilename);
                 var success = await ProcessFileAsync(sourceFile);
                 if (success)
                 {
                     File.Move(tempFilename, sourceFile + ".done");
                 }
                 else 
                 {
                     File.Move(tempFilename, sourceFile);
                 }
            }
        }
        catch 
        {
             // Rename the file back to be attempted later.
             File.Move(tempFilename, sourceFile);
        }
    }
