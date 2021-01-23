    private static void Test()
    {
        var lFileInfo = new FileInfo(@"C:\Neues Textdokument.txt");
        lFileInfo.AttributesSet(FileAttributes.Hidden | FileAttributes.ReadOnly);
        lFileInfo.AttributesSet(FileAttributes.Temporary);
        var lBool1 = lFileInfo.AttributesIsSet(FileAttributes.Hidden);
        var lBool2 = lFileInfo.AttributesIsSet(FileAttributes.Temporary);
        var lBool3 = lFileInfo.AttributesIsSet(FileAttributes.Encrypted);
        var lBool4 = lFileInfo.AttributesIsSet(FileAttributes.ReadOnly | FileAttributes.Temporary);
        var lBool5 = lFileInfo.AttributesIsSet(FileAttributes.ReadOnly | FileAttributes.Encrypted);
        var lBool6 = lFileInfo.AttributesIsAnySet(FileAttributes.ReadOnly | FileAttributes.Temporary);
        var lBool7 = lFileInfo.AttributesIsAnySet(FileAttributes.ReadOnly | FileAttributes.Encrypted);
        var lBool8 = lFileInfo.AttributesIsAnySet(FileAttributes.Encrypted);
        lFileInfo.AttributesRemove(FileAttributes.Temporary);
        lFileInfo.AttributesRemove(FileAttributes.Hidden | FileAttributes.ReadOnly);
    }
