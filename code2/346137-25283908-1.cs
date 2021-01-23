    private static void Test()
    {
        var lFileInfo = new FileInfo(@"C:\Neues Textdokument.txt");
        lFileInfo.AttributesSet(FileAttributes.Hidden | FileAttributes.ReadOnly);
        lFileInfo.AttributesSet(FileAttributes.Temporary);
        lFileInfo.AttributesRemove(FileAttributes.Temporary);
        lFileInfo.AttributesRemove(FileAttributes.Hidden | FileAttributes.ReadOnly);
    }
