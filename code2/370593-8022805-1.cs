    public static bool TempDirectoryContainsXmlFiles()
    {
        DirectoryInfo di = new DirectoryInfo(@"c:\temp");
        return di.GetFiles("*.xml").Any();
    }
