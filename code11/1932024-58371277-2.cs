    Get all directories name.
    
     string [] subdirectoryEntries1 = Directory.GetDirectories("folder1path");
     string [] subdirectoryEntries2 = Directory.GetDirectories("folder1path");
 
    Get all files name
      foreach(string dir in subdirectoryEntries1)
      {
         string [] fileEntries = Directory.GetFiles(dir);
         foreach(string file in fileEntries )
         {
           Console.WriteLine(file.Name);
         }
      }
    
    now you can use LINQ
    
    var diff1= subdirectoryEntries1.Except(subdirectoryEntries2)
    var diff2= subdirectoryEntries2.Except(subdirectoryEntries1)
