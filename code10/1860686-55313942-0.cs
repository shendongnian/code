      //put all paths in array reading line by line
      string[] paths = System.IO.File.ReadAllLines(@"path-to\list.txt");
      
      //get line by line paths
      foreach (string path in paths)
      {
            if (Directory.Exists(path))
            {
                //deletes all files and parent
                //recursive:true, deletes subfolders and files
                Directory.Delete(path, true);
                //create parent folder
                Directory.CreateDirectory(path);
            }
                 
       }//end outer for
