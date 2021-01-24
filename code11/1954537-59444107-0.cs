    using System.IO;
    using System.IO.Compression;
    public static byte[] Change(string path)
    {
        // Make a temporary directory
        var myTempDir = new DirectoryInfo(Path.Join(Path.GetTempPath(), Path.GetRandomFileName() ));
        myTempDir.Create();
        // Extract all the XML files in the docx to that temporary directory
        using (ZipArchive zipArchive = ZipFile.OpenRead(path))
            zipArchive.ExtractToDirectory(myTempDir.FullName);
        // Read in the main document XML
        FileInfo docFile = new FileInfo(Path.Join(myTempDir.FullName, "word", "document.xml"));
        string rawXML = File.ReadAllText(docFile.FullName);
        // Manipulate it-- warning, this could break the whole thing
        rawXML = rawXML.Replace("winter", "spring");
        // Save the manipulated xml back over the old file
        docFile.Delete();
        File.WriteAllText(docFile.FullName, rawXML);
        // Zip our temporary directory back into a docx file
        FileInfo tempFile = new FileInfo(Path.GetTempFileName());
        ZipFile.CreateFromDirectory(myTempDir.FullName, tempFile.FullName);
        // Read the raw bytes in from our new file
        byte[] rawBytes = File.ReadAllBytes(tempFile.FullName);
        return rawBytes;
    }
