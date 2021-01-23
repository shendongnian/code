    public void CreateThumbnail(double wid, double hght, bool Isprint)
    {
       string saveAt = "C:\\Users\\a\\Desktop\\a test";  
       string b= "C:\\Users\\a\\Desktop\\b test\\iceland"
       ProcessFolder(b, saveAt, wid, hght, Isprint);
    }
    public void ProcessFolder(string sourceFolder, string destFolder, double wid, double hght, bool Isprint)
    {
      string[] dirs = Directory.GetDirectories(sourceFolder, "*.*");
      foreach (string dir in dirs)
      {
        DirectoryInfo diSource = new DirectoryInfo(dir);
        string outputPath = Path.Combine(destFolder, diSource.Name);
        Directory.CreateDirectory(outputPath);
                
        foreach (FileInfo f in directory.GetFiles("*.*"))
        {
          using (Image imagesize = Image.FromFile(f.FullName)) 
          {
               // the code here remains the same
          }
        }
        ProcessFolder(dir, destFolderName); //call recursively for any subfolders
       }
     }
