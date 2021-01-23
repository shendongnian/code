        public static List<String> GetSubfoldersAndFiles(DirectoryInfo di, int deep)
        {
           List<string> myContent = new List<string>();
           foreach(FileInfo fi in di.GetFiles())
           {
              myContent.Add(fi.FullName);
           }
           if(deep > 0)
           {
              foreach(DirectoryInfo subDi in di.GetDirectories())
              {
                  myContent.AddRange(GetSubfoldersAndFiles(subDi, deep - 1).ToArray());
              }
           }
           return myContent;
        }
