    byte[] bytesDoc = byteFromDatabase();
    //Write to a temp file
    File.WriteAllBytes(@"D:\EditedFile.docx", bytesDoc );
    
    var app = new Microsoft.Office.Interop.Word.Application();
    Document doc = app.Documents.Open(@"D:\EditedFile.docx");
    
    var pageCount = doc.ComputeStatistics(
                       Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages);
    
    doc.Close();
    app.Quit();
