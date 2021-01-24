    byte[] byteArray = File.ReadAllBytes(sDocpath + inputPath);
    using (MemoryStream stream = new MemoryStream())
    {
       stream.Write(byteArray, 0, (int)byteArray.Length);
       using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(stream, true))
         {
         // Change from template type to workbook type
         spreadsheetDoc.ChangeDocumentType(DocumentFormat.OpenXml.SpreadsheetDocumentType.MacroEnabledWorkbook);
         }
       File.WriteAllBytes(dirPath + outputPath, stream.ToArray());
    }
