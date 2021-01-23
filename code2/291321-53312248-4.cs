    string documentPath = @"C:\test.docx"; // can be modified with dynamic paths, file name from database, etc.
    byte[] contentBytes = null;
    // … Fill contentBytes from the database, then...
    
    // Create the Word document using the path
    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(documentPath, true))
    {
        // This should get you the XML string...
        string docText = System.Text.Encoding.ASCII.GetString(contentBytes);
        // Then we write it out...
        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
        {                    
            sw.Write(docText);
        } 
    }
