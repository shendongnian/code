    using Word = Microsoft.Office.Interop.Word;
        
    object missing = System.Type.Missing;
        
    Word.Selection PosRange = Globals.ThisAddIn.Application.Selection;
    Microsoft.Office.Interop.Word.ContentControl cntCtrl;
    cntCtrl = PosRange.Range.ContentControls.Add(Microsoft.Office.Interop.Word.WdContentControlType.wdContentControlRichText, ref missing);
         
    object fldType = Microsoft.Office.Interop.Word.WdFieldType.wdFieldMergeField;
    object fldText = "Employee";
    Microsoft.Office.Interop.Word.Field fld = cntCtrl.Range.Fields.Add(cntCtrl.Range, ref fldType, ref fldText);
    cntCtrl.LockContents = true;
