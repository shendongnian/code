    if (System.IO.File.Exists(filePath))
        {
         System.IO.File.Delete(filePath);
         System.Threading.Thread.Sleep(20);
        }
