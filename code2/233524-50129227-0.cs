    // Copy image to clickboard.
    System.Windows.Forms.Clipboard.SetImage( Properties.Resources.your_resource_name);
    
    //Select an location where you want to put the image
    section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Select();
    
    // Page onto the document. wordApp is the instance of Microsoft.Office.Interop.Word.Application
    wordApp.Selection.Paste();
