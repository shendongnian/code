    /// <summary>
    /// Addes the given FileAttributes to the given File.
    /// It's possible to combine FileAttributes: FileAttributes.Hidden | FileAttributes.ReadOnly
    /// </summary>
    public static void AttributesSet(this FileInfo pFile, FileAttributes pAttributes)
    {
        pFile.Attributes = pFile.Attributes | pAttributes;
        pFile.Refresh();
    }
    /// <summary>
    /// Removes the given FileAttributes from the given File.
    /// It's possible to combine FileAttributes: FileAttributes.Hidden | FileAttributes.ReadOnly
    /// </summary>
    public static void AttributesRemove(this FileInfo pFile, FileAttributes pAttributes)
    {
        pFile.Attributes = pFile.Attributes & ~pAttributes;
        pFile.Refresh();
    }
