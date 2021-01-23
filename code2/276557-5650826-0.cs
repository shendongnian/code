    public static class IOExtension
       {
          public static void PurgeDirectory(this DirectoryInfo d)
          {
             string path = d.FullName;
    
             Directory.Delete(d.FullName,true);//Delete with recursion
             Directory.CreateDirectory(path);
             
          }
       }
