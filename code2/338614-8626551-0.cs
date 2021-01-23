    static function to open the folder a file is located in.  
    I use in a static common class for many of my projects.
    public static void ShowFileInFolder(string filepath)
    {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = Path.GetDirectoryName(filepath);
            prc.Start();
    }
