    StringBuilder sb = new StringBuilder();
    sb.Append(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
    sb.Append("\\");
    sb.Append("WpfApplicationClickOnce"); //pubslisher name
    sb.Append("\\");
    sb.Append("WpfApplicationClickOnce.appref-ms "); //application name
    string shortcutPath = sb.ToString();
    Process.Start(shortcutPath, "argumentTest");
