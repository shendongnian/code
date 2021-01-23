    Microsoft.Office.Interop.Word.Application _App = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document _Doc =  _App.Documents.Open("c:/xxx.rtf");
    
    object _PdfFileName = "C:/xxx3.doc";
    Object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
    
    _Doc.SaveAs2(ref _PdfFileName, ref FileFormat);
