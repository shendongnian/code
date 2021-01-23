     using System.IO;
     string[] files = Directory.GetFiles("pathToFiles");
     foreach (string file in files) {
         FileStream fs = null;
         try {
             //try to open file for exclusive access
             fs = new FileStream(
                 file, 
                 FileMode.Open, 
                 FileAccess.Read, //we might not have Read/Write privileges
                 FileShare.None   //request exclusive (non-shared) access
             );
         } 
         catch (IOException ioe) {
             //File is in use by another process, or doesn't exist
         }
         finally {
             if (fs != null)
                 fs.Close();
         }
     }
