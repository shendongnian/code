    private void urlShortcutToDesktop(string linkName, string linkUrl)
    {
        string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    
        using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
        {
            writer.WriteLine("[InternetShortcut]");
            writer.WriteLine("URL=" + linkUrl);
            writer.Flush();
        }
    }
