    using System.IO; 
    private void EmptyFolder(DirectoryInfo directoryInfo)
    {
      foreach (FileInfo file in directoryInfo.GetFiles())
      {
        file.Delete();
      }
      foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
      {
        EmptyFolder(subfolder);
      }
    }
