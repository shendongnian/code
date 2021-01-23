      Object fileName = "C:\\Documents and Settings\\saravanan\\Desktop\\test1.docx";
      axFramerControl1.Open(fileName, true, 0, "", "");
      Microsoft.Office.Interop.Word.Document wordDoc =     Microsoft.Office.Interop.Word.Document)axFramerControl1.ActiveDocument;
      Microsoft.Office.Interop.Word.Application wordApp = wordDoc.Application;
      Microsoft.Office.Interop.Word.Range r = wordDoc.Paragraphs[15].Range;
     //object dir = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;
     //r.Collapse(ref dir);
     r.Select();
