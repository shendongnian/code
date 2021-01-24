    var dir="";
    foreach (string f in Directory.GetFiles(dir,"*.*",SearchOption.AllDirectories))
    {
        string filename = f.Substring(rootDir.Length);
        var directoryName = new FileInfo(filename).Directory.FullName;
        if(directoryName!=dir)
        {
          Console.WriteLine(filename);
          dir= directoryName ;
        }
        Console.WriteLine(filename);
    }
    
    
      
