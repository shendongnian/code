    List<FileInfo> DirSearch(string sDir)
         {
             List<FileInfo> filesList = new List<FileInfo>();
             try
             {
                 foreach (string d in Directory.GetDirectories(sDir))
                 {
                     foreach (string f in Directory.GetFiles(d, txtFile.Text))
                     {
                        fileList.Add(new FileInfo(f));
                      }
                     DirSearch(d);
                 }
             }
             catch (System.Exception excpt)
             {
                 Console.WriteLine(excpt.Message);
             }
             return fileList;
         } 
