    using System;
    using System.IO;     
   
       public void CreateDirectories(string uploadDirPath, string userName)
       {
         string userDirPath= uploadDirPath + "\\" + userName ;
      
         if (!Directory.Exists(uploadDirPath))
         {
           Directory.CreateDirectory(uploadDirPath);
           
           if (!Directory.Exists(userDirPath))
               Directory.CreateDirectory (userDirPath);
         }
       }
