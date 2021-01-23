    byte[] byteArray = File.ReadAllBytes("c:\\data\\hello.docx");
    using (MemoryStream stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, (int)byteArray.Length);
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
        {
           // Do work here
        }
        // Save the file with the new name
        File.WriteAllBytes("C:\\data\\newFileName.docx", stream.ToArray()); 
    }
