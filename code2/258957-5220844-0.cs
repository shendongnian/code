    byte[] byteArray = File.ReadAllBytes("C:\\temp\\oldName.xltx");
    using (MemoryStream stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, (int)byteArray.Length);
        using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(stream, true))
        {
           // Do work here
        }
        File.WriteAllBytes("C:\\temp\\newName.xlsx", stream.ToArray()); 
    }
