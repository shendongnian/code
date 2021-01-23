    string mt = "application/unknown";
    string ext = Path.GetExtension(filename).ToLower();
    var regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
    if (regKey != null) {
      var tempMt = regKey.GetValue("Content Type");
      if (tempMt != null) {
        tempMt = regKey.GetValue("Content Type").ToString();
      }
    }
