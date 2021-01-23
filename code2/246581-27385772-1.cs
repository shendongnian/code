    Microsoft.Office.Interop.Word.Application _App = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document _Doc =  _App.Documents.Open("c:/xxx.rtf");
    
    object _DocxFileName = "C:/xxx.docx";
    Object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
    
    _Doc.SaveAs2(ref _DocxFileName, ref FileFormat);
