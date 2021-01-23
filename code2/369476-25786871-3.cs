    public void CreateZip(string sourceName, string targetArchive)
    {
        ProcessStartInfo p = new ProcessStartInfo();
        p.FileName = "7za.exe";
        p.Arguments = string.Format("a -tgzip \"{0}\" \"{1}\" -mx=9", targetArchive, sourceName);
        p.WindowStyle = ProcessWindowStyle.Hidden;
        Process x = Process.Start(p);
        x.WaitForExit();
    }
