    wordDoc.Tables.Add(b.Range,newsheet.UsedRange.Rows.Count,newsheet.UsedRange.Columns.Count);
    Microsoft.Office.Interop.Word.Table table = b.Range.Tables[1];
    newsheet.UsedRange.Copy();
    table.Range.Select(); 
    wordApp.Selection.Paste();
