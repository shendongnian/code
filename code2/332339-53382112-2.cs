    //byte[] byteArray = File.ReadAllBytes("Test.docx"); // you might be able to assign your bytes here, instead of from a file?
    using (MemoryStream mem = new MemoryStream())
    {
        mem.Write(byteArray, 0, (int)byteArray.Length);
        using (WordprocessingDocument wordDoc =
                WordprocessingDocument.Open(mem, true))
        {
            // do your updates
        }
        // But you will still need to save it to the file system here....
        // You would update "documentPath" to a new name first...
        documentPath = @"C:\temp\newDoc.docx";
        using (FileStream fileStream = new FileStream(documentPath,
                System.IO.FileMode.CreateNew))
        {
            mem.WriteTo(fileStream);
        }
    }
    // And then read the bytes back in, to save it to the database
    byteArray = File.ReadAllBytes(documentPath); // new bytes, ready for DB saving
