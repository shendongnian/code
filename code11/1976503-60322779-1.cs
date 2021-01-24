    byte[] bytesDoc = byteFromDatabase();
    var tempFile = Path.Combine(Path.GetTempPath(), formLanguage.FileName);
    //Write to a temp file
    File.WriteAllBytes(tempFile , bytesDoc );
    
    var app = new Microsoft.Office.Interop.Word.Application();
    Document doc = app.Documents.Open(tempFile);
    
    var pageCount = doc.ComputeStatistics(
                       Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages);
    
    doc.Close();
    app.Quit();
