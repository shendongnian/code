    static void Main(string[] args)
    {
      using (var resultZip = new ZipFile())
      {
        foreach (var zipFileName in args)
        {
          using (var inputZip = ZipFile.Read(zipFileName))
          {
            Add(resultZip, inputZip, Path.GetFileNameWithoutExtension(zipFileName));
          }
        }
        resultZip.Save("all.zip");
      }
    }
    /// <summary>
    /// Merge the complete content of <paramref name="inputZip"/> to <paramref name="resultZip"/>, preserving the folded structure
    /// </summary>
    /// <param name="resultZip">The ZIP file to merge to</param>
    /// <param name="inputZip">The ZIP file to merge from</param>
    /// <param name="folder">The folder name in <paramref name="resultZip"/> where the content should be put, or null for the root.</param>
    private static void Add(ZipFile resultZip, ZipFile inputZip, string folder)
    {
      foreach (var inputEntry in inputZip.Entries)
      {
        using (var inputStream = inputEntry.OpenReader())
        using (var memoryStream = new MemoryStream())
        {
          inputStream.CopyTo(memoryStream);
          var resultFileName = string.IsNullOrEmpty(folder) ? inputEntry.FileName : folder + "/" + inputEntry.FileName;
          resultZip.AddEntry(resultFileName, memoryStream.ToArray());
        }
      }
    }
