    public static string HtmlToCrap(String HtmlSource)
    {
    string HtmlFile = "";
    System.IO.File.WriteAllText(HtmlFile, HtmlSource);
    
    
    Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
    
    oDoc = oWord.Documents.Add();
    oWord.Visible = false;
    
    oDoc = oWord.Documents.Open(HtmlFile);
    
    oDoc.SaveAs(@"C:\WORDhtml.html", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML);
    
    oDoc.Close(false);
    oWord.Quit();
                   
    return ReadFile(@"C:\WORDhtml.html");
    }
