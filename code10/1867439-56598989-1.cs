    foreach (RemoteFileInfo fileInfo in directory.Files)
    {
       Console.WriteLine("{0} with size {1}, permissions {2} and last modification at {3}",
                          fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions, 
                          fileInfo.LastWriteTime);
            
       Console.WriteLine(fileInfo.FullName);
       
       string FilePath = fileInfo.FullName;
            
       if (session.FileExists(FilePath))
       {
          Console.WriteLine("Folder exists");
            
          var a = session.EnumerateRemoteFiles(FilePath, null, 
                  EnumerationOptions.AllDirectories);
          
          Console.WriteLine(a.Count());
            
       }
            
    }
