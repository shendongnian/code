    private void appShortcutToDesktop(string linkName)
    {
        string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    
        using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
        {
            string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
            writer.WriteLine("[InternetShortcut]");
            writer.WriteLine("URL=file:///" + app);
            writer.WriteLine("IconIndex=0");
            string icon = app.Replace('\\', '/');
            writer.WriteLine("IconFile=" + icon);
            writer.Flush();
        }
    }
