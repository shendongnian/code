    string startFolder = @"c:\Download\";
    // Take a snapshot of the file system.
    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
    // This method assumes that the application has discovery permissions
    // for all folders under the specified path.
    IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
    //Create the query
    IEnumerable<System.IO.FileInfo> fileQuery =
        from file in fileList
        where file.Extension == ".txt"
        orderby file.Name
        select file;
    // Create and execute a new query by using the previous 
    // query as a starting point. fileQuery is not 
    // executed again until the call to Last()
    var newestFile =
        (from file in fileList
         orderby file.CreationTime
         select new { file.FullName, file.CreationTime })
        .Last();
    Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}",
        newestFile.FullName, newestFile.CreationTime);
    // Keep the console window open in debug mode.
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();
