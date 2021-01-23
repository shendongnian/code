    private static void TreeScan( string sDir )
    {
        foreach (string f in Directory.GetFiles( sDir ))
        {
            //Save
        }
        foreach (string d in Directory.GetDirectories( sDir ))
        {
            TreeScan( sDir );
        }
    }
