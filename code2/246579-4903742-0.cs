    var wordApp = new Microsoft.Office.Interop.Word.Application();
    var currentDoc = wordApp.Documents.Open(@"C:\TestDocument.rtf");
    currentDoc.SaveAs(@"C:\TestDocument", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault);
    currentDoc.Close();
    wordApp.Quit();
