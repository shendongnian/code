    MailItem mi;
    foreach (var selection in Globals.ThisAddIn.Application.ActiveExplorer().Selection)
    {
     if (selection is MailItem)
     {   
       mi= (MailItem)selection;
       // your other code...
     }
     }
    mi=null;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    
