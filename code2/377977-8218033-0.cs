      private static bool GetExclusiveAccess(string filePath)
      {
         try
         {
            FileStream objFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            objFile.Close();
            return true;
         }
         catch (IOException)
         {
            return false;
         }
      }
