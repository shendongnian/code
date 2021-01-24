    string path =@ "D:\TEST\PROJ\Repo\";
    DirectoryInfo directory = new DirectoryInfo(path);
    DirectoryInfo[] subDirectories = directory.GetDirectories();
    
    foreach(DirectoryInfo folder in subDirectories)
    {
         string subpath = Path.Combine( @ "D:\TEST\PROJ\Repo\", folder.Name);
         string[] filePaths = Directory.GetFiles(subpath, "fileserver.config");
         if(filePaths.Any())
            Console.WriteLine(subpath);
    }
