        public void WriteFile(string filePath, StoredFile file, bool tempLocation)
        {
         // [snip..]
            try
            {
                 fileStream.Write(data, 0, data.Length);
                 fileStream.Flush();
                 fileStream.Close();
    
                 if (tempLocation)
                 {
                    Process p = System.Diagnostics.Process.Start(@strPath);
                    p.WaitForExit();
                    File.Delete(strPath);
                 }
            }
            finally
            {
                if (fileStream != null)
                  fileStream.Dispose();   
            }
        }
