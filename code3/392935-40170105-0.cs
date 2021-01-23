    //----------------------------------------------------------------------------------------------------
    /// <summary>Gets a boolean indicating whether the specified path is a local path or a network path.</summary>
    /// <param name="path">Path to check</param>
    /// <returns>Returns a boolean indicating whether the specified path is a local path or a network path.</returns>
    public static Boolean IsNetworkPath(String path) {
      Uri uri = new Uri(path);
      if (uri.IsUnc) {
        return true;
      }
      DriveInfo info = new DriveInfo(path);
      if (info.DriveType == DriveType.Network) {
        return true;
      }
      return false;
    }
