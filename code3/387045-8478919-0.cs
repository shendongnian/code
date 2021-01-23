    public static bool IsDirectory(string path) {
      if (!String.IsNullOrEmpty(path)) {
        if (Path.DirectoryExists(path)) {
          DirectoryInfo dir = new DirectoryInfo(path);
            return ((dir.Attributes & FileAttributes.Directory) == FileAttributes.Directory);
        }
      }
      return false;
    }
