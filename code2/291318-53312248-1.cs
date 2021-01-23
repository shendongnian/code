    string sourceFilePath = @"C:\test.docx";
    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
    var document = wordApp.Documents.Open(sourceFilePath);
    string docText = document.WordOpenXML;
    byte[] bytes = Encoding.ASCII.GetBytes(docText);
