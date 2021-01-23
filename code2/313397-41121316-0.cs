    using Microsoft.Office.Interop.Outlook;
    using Microsoft.Office.Interop.Word;
    public void Click(Office.IRibbonControl Control)
    {
        string documentPath = @"C:\\Documents";
        Outlook.Inspector = OutlookApp.ActiveInspector();
        Document we = inspector.WordEditor as Document;
        Find wf = we.Range().Find;
        wf.Application.Selection.Range.ImportFragment(documentPath);    
    }
