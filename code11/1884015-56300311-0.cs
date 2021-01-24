    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace RenameWithVersion
    {
      public class Program
      {
        public static void Main(String[] args)
        {
          if (args.Length != 1)
            throw new Exception("There should only be one command line parameter - the file to be renamed.");
    
          var oldFilename = Path.GetFullPath(args[0]);
    
          if (!File.Exists(oldFilename))
            throw new Exception($"File '{oldFilename}' does not exist.");
    
          var oldFilenameWithoutExt = Path.ChangeExtension(oldFilename, null);
          var fileVersion = FileVersionInfo.GetVersionInfo(oldFilename).FileVersion;
          var ext = Path.GetExtension(oldFilename);
    
          var newFilename = $"{oldFilenameWithoutExt}{fileVersion}{ext}";
    
          File.Delete(newFilename);
          File.Move(oldFilename, newFilename);
        }
      }
    }
