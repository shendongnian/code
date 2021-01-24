    static void Main(string[] args)
    {
        CleanupFiles(xxx, xxx, true);
    }
    void CleanupFiles(String sPath, int iDayDelAge, bool root)
    {
        if (iDayDelAge != 0) // enabled?
        {
            // Check for aged files to remove
            foreach (String file in Directory.GetFiles(sPath))
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastWriteTime < DateTime.Now.AddDays(iDayDelAge * -1))  // overdue?
                {
                    fi.Delete();
                }
            }
            // Recursively search next subfolder if available
            foreach (String subfolder in Directory.GetDirectories(sPath))
            {
                CleanupFiles(subfolder, iDayDelAge, false);
            }
            // Remove empty folder
            if (Directory.GetFiles(sPath).Length == 0 && Directory.GetDirectories(sPath).Length == 0 && !root)
            {
                Directory.Delete(sPath);
            }
        }
    }
