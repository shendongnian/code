    // There's most likely a better way to do this than using this searcher 
    // but it's the most reliable way I've found
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_OperatingSystem");
    ManagementObjectCollection osCollection = searcher.Get();
    foreach (ManagementBaseObject os in osCollection)
    {
        string[] languages = (string[])os.GetPropertyValue("MUILanguages");
        foreach (string language in languages)
        {
            Console.WriteLine(language);
        }
    }
