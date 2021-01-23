    Public List<String> GetSubfoldersAndFiles(DirectoryInfo di, int deep)
    {
       List<string> myContent = new List<string>();
       foreach(FileInfo fi in di.GetFiles())
       {
          myContent.add(fi.FullName);
       }
    
       if(deep > 0)
       {
          foreach(DirectoryInfo subDi in di.getDirectories())
          {
             myContent.AddRange(GetSubFoldersAndFiles(subDi, --deep).ToArray());
          }
       }
    
       return myContent;
    }
