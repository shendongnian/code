    int copyCount = 0;
    while (File.Exists(ValidName))
    {
        const string CopyName = "(Copy)";
        string copyString = copyCount == 0 ? CopyName : (CopyName + "(" + copyCount + ")");
        string tempName = Justname + copyString + Extension2 + Extension;
        ValidName = Path.Combine(outputPath, tempName);
        copyCount++;
    }
