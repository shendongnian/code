    /// <summary>
    /// Write a byte[] to a new file at the location where you choose
    /// </summary>
    /// <param name="byteArray">byte[] that consists of file data</param>
    /// <param name="newDocument">Path to where the new document will be written</param>
    public static void WriteFile(byte[] byteArray, string newDocument)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            stream.Write(byteArray, 0, (int)byteArray.Length);
            // Save the file with the new name
            File.WriteAllBytes(newDocument, stream.ToArray());
        }
    }
