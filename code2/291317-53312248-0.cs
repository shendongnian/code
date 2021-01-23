    Microsoft.Office.Interop.Word.Document d = new Microsoft.Office.Interop.Word.Document();
    // All of your building of the document was here
    // The object must be updated with content
    string docText = d.WordOpenXML;  // this assumes content is here
    byte[] bytes = Encoding.ASCII.GetBytes(docText);
