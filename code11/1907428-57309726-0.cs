     using System.IO;
     ...
     String path = @"c:\MyFile.txt";
 
     // Read file, remove LF (which is "\n")
     string text = File.ReadAllText(path).Replace("\n", ""); 
     
     // Write text back
     File.WriteAllText(path, text);
