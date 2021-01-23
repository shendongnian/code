    string GetPath(string extension)
    {
        var appName = (string)Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension).GetValue(null);
        var openWith = (string)Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(appName + @"\shell\open\command").GetValue(null);
        var appPath =  System.Text.RegularExpressions.Regex.Match(openWith, "[a-zA-Z0-9:,\\\\\\. ]+").Value.Trim();
        return new FileInfo(appPath).Directory.FullName;
    }
    GetPath(".rar");
