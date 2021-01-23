    [DllImport("kernel32.dll")]
    private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);
    private List<string> GetKeys(string iniFile, string category)
    {
            
        byte[] buffer = new byte[2048];
        GetPrivateProfileSection(category, buffer, 2048, iniFile);
        String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
        List<string> result = new List<string>();
        foreach (String entry in tmp)
        {
            result.Add(entry.Substring(0, entry.IndexOf("=")));
        }
        return result;
    }
