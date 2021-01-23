    private IEnumerable<String> FindAccessableFiles(string path, string file_pattern)
    {
      var list = new List<string>();
      // if path is already a file, return it
      if (File.Exists(path))
      {
        yield return path;
        yield break;
      }
      // If it's not a file, or a directory, stop
      if (!Directory.Exists(path))
         yield break;
      if (null == file_pattern)
        file_pattern = "*.*";
      var top_directory = new DirectoryInfo(path);
      // Enumerate the files just in the top directory.
      var files = top_directory.EnumerateFiles(file_pattern);
      while (true)
      {
         FileInfo file = null; // Define outside try/catch for use with yield
         try
         {
           file = files.First();
           files = files.Skip(1);
         }
         catch (UnauthorizedAccessException)
           continue;
         catch (PathTooLongException)
           continue;
         catch (InvalidOperationException) // ran out of entries
           break;
         yield return file.FullName;
       }
       var dirs = top_directory.EnumerateDirectories("*");
       while (true)
       {
         DirectoryInfo dir = null;
         try
         {
           dir = dirs.First();
           dirs = dirs.Skip(1);
         }
         catch (UnauthorizedAccessException)
           continue;
         catch (PathTooLongException)
           continue;
         catch (InvalidOperationException) // ran out of entries
           break;
         foreach (var subpath in FindAccessableFiles(dir.FullName, file_pattern))
           yield return subpath;
       }
    }
