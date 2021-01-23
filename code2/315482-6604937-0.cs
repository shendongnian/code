    private static void TreeScan(string sDir)
    {
        foreach (string d in Directory.GetDirectories(sDir))
        {
            TreeScan(d, client);
        }
        foreach (string f in Directory.GetFiles(d))
        {
            //Save file f
        }
    }
