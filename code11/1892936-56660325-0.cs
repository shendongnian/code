    public void DeleteFunction(string FolderName)
        {
            var folderpath = AppDomain.CurrentDomain.BaseDirectory+FolderName;
           var filescount= Directory.GetFiles(folderpath, "*", SearchOption.AllDirectories).Length;
           string[] files = Directory.GetFiles(folderpath );
           List<string> filenames = new List<string>();
                                  // ^^^^^^^^^^^^^^^^ this was missing in your code 
           for(int i=0;i<filescount;i++)
           {
               filenames.Add(Path.GetFileName(files[i]));
             // ^^^^^^^^^^^^^^^^ You were missing .Add() function to insert file name to list
           }
        }
