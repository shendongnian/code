    public static string GetMimeType(string fileName)
    {
        string mimeType = "application/unknown";
        string ext = Path.GetExtension(fileName).ToLower();
        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); // henter info fra windows registry
        if (regKey != null && regKey.GetValue("Content Type") != null)
        {
            mimeType = regKey.GetValue("Content Type").ToString();
        }
        else if (ext == ".png") // a couple of extra info, due to missing information on the server
        {
            mimeType = "image/png";
        }
        else if (ext == ".flv")
        {
            mimeType = "video/x-flv";
        }
        return mimeType;
    }
