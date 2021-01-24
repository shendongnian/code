       if (System.IO.File.Exists(filePath))
        {
          System.GC.Collect();
          System.GC.WaitForPendingFinalizers();
          System.IO.File.Delete(filePath);
        }
