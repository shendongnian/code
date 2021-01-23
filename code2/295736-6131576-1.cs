      DirectoryInfo dirInfo = new DirectoryInfo(sFolder);
      // so you can change the extension programmatically
      string extension = @".done";
      string allFiles = @"*" + extension;
      FileInfo[] fileEntries = dirInfo.GetFiles(allFiles, System.IO.SearchOption.TopDirectoryOnly);
      foreach (FileInfo fileInfo in fileEntries)
      {             
         // stop processing if the db has finished loading
         // use the Extension property; Name will not be a match
         if (fileInfo.Extension == extension)    
         {
            break;
         }
         // process file
      }
