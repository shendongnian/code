       using System.IO;
       using System.Linq;
    
       ...
    
       var result = File
         .ReadLines("file1.txt")
         .Intersect(File.ReadLines("file2.txt"))
         .Intersect(File.ReadLines("file3.txt"));
    
       File.WriteLines("file_common.txt", result);
