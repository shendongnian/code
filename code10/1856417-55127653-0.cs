      try
      {
        string filename = System.IO.Path.GetTempFileName() + "_" + bidScenarioId.ToString();
        System.IO.File.WriteAllBytes(filename, bytes);
        …
      }
      finally
      {
         System.IO.File.Delete(filename);
      }
