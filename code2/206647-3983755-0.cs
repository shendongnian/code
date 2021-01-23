    Document wordDocument;
    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); 
    wordDocument = word.Documents.Open(saveFileDialog.FileName);
    wordDocument.TablesOfContents[1].Update();
    wordDocument.Save();
    word.Quit();
