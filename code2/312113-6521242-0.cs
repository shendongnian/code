    using System.IO;
 
    public static void Main()
    {
     ClearFolder(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))); // Execute ClearFolder() on the IE's cache folder
     }
 
     void ClearFolder(DirectoryInfo diPath)
     {
       foreach (FileInfo fiCurrFile in diPath.GetFiles())
       {
          fiCurrFile.Delete();
       }
       foreach (DirectoryInfo diSubFolder in diPath.GetDirectories())
       {
          ClearFolder(diSubFolder); // Call recursively for all subfolders
       }
    }
