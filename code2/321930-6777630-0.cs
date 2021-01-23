    // Document
    object saveOptionsObject = saveDocument ? Word.WdSaveOptions.wdSaveChanges : Word.WdSaveOptions.wdDoNotSaveChanges;
    this.WordDocument.Close(ref saveOptionsObject, ref Missing.Value, ref Missing.Value);
        
    // Application
    object saveOptionsObject = Word.WdSaveOptions.wdDoNotSaveChanges;
    this.WordApplication.Quit(ref saveOptionsObject, ref Missing.Value, ref Missing.Value);	
    
    GC.Collect();
    GC.WaitForPendingFinalizers();
