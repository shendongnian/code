    // objects I use in the code below
    // instanciate wordapp as the Word application object
    Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
    
    
    // create missing object for compatibility with C# .NET 3.5
    Object oMissing = System.Reflection.Missing.Value;
    
    // define worddoc as the word document object
    Microsoft.Office.Interop.Word.Document worddoc = wordapp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    // define s as the selection object
    Microsoft.Office.Interop.Word.Selection s = wordapp.Selection;
    // code for the page numbers
    // move selection to page footer (Use wdSeekCurrentPageHeader for header)
    worddoc.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageFooter;
    
    // Align right
    s.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                
    // start typing
    worddoc.ActiveWindow.Selection.TypeText("Page ");
    // create the field  for current page number
    object CurrentPage = Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage;
    
    // insert that field into the selection
    worddoc.ActiveWindow.Selection.Fields.Add(s.Range, ref CurrentPage, ref oMissing, ref oMissing);
    
    // write the "of"
    worddoc.ActiveWindow.Selection.TypeText(" of ");
    // create the field for total page number.
    object TotalPages = Microsoft.Office.Interop.Word.WdFieldType.wdFieldNumPages;
    // insert total pages field in the selection.
    worddoc.ActiveWindow.Selection.Fields.Add(s.Range, ref TotalPages, ref oMissing, ref oMissing);
                
    // return to the document main body.
    worddoc.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;
