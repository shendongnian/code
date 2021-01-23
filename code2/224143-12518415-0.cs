    /// <summary>
    /// Convert a partial file path to a partial url path.
    /// </summary>
    /// <param name="partialFilePath">The partial file path.</param>
    /// <returns>A partial url path.</returns>
    public static string ConvertPartialFilePathToPartialUrlPath(
        string partialFilePath)
    {
        if (partialFilePath == null)
            return null;
        return string.Join("/", 
            partialFilePath.Split('/', '\\')
                .Select(part => Uri.EscapeDataString(part)));
    }
