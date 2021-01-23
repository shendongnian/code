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
    /// <summary>
    /// Checks the given File on the given Attributes.
    /// It's possible to combine FileAttributes: FileAttributes.Hidden | FileAttributes.ReadOnly
    /// </summary>
    /// <returns>True if any Attribute is set, False if non is set</returns>
    public static bool AttributesIsAnySet(this FileInfo pFile, FileAttributes pAttributes)
    {
        return ((pFile.Attributes & pAttributes) > 0);
    }
    /// <summary>
    /// Checks the given File on the given Attributes.
    /// It's possible to combine FileAttributes: FileAttributes.Hidden | FileAttributes.ReadOnly
    /// </summary>
    /// <returns>True if all Attributes are set, False if any is not set</returns>
    public static bool AttributesIsSet(this FileInfo pFile, FileAttributes pAttributes)
    {
        return (pAttributes == (pFile.Attributes & pAttributes));
    }
