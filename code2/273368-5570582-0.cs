    internal static class StoWindowsString
    {
      /// <summary>
      ///   Searches for a text resource in a Windows library.
      ///   Sometimes, using the existing Windows resources, you can
      ///   make your code language independent and you don't have to
      ///   care about translation problems.
      /// </summary>
      /// <example>
      ///   btnCancel.Text = StoWindowsString.Load("user32.dll", 801, "Cancel");
      ///   btnYes.Text = StoWindowsString.Load("user32.dll", 805, "Yes");
      /// </example>
      /// <param name="LibraryName">Name of the windows library like
      ///   "user32.dll" or "shell32.dll"</param>
      /// <param name="Ident">Id of the string resource.</param>
      /// <param name="DefaultText">Return this text, if the resource
      ///   string could not be found.</param>
      /// <returns>Desired string if the resource was found, otherwise
      ///   the DefaultText</returns>
      public static string Load(string libraryName, uint Ident, string DefaultText)
      {
        IntPtr libraryHandle = GetModuleHandle(libraryName);
        if (libraryHandle != IntPtr.Zero)
        {
          StringBuilder sb = new StringBuilder(1024);
          int size = LoadString(libraryHandle, Ident, sb, 1024);
          if (size > 0)
            return sb.ToString();
          else
            return DefaultText;
        }
        else
        {
          return DefaultText;
        }
      }
    
      [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
      private static extern IntPtr GetModuleHandle(string lpModuleName);
    
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      private static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);
    }
