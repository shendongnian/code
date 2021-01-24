    //Get the active document.
    Word.Document activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
    //Check, if Active Window is blank, then we can close it. Once the new Window is Opened. If not, 
    //we'll open the document in new window
    bool closeParentWindow = activeDocument.Content.End - activeDocument.Content.Start == 1 ;
    string activeDocName = activeDocument.Name;
                        
    //Add the new document which's supposed to open
    Word.Document newDoc = this.Application.Documents.Add(path, System.Type.Missing, System.Type.Missing);
    newDoc.ActiveWindow.Caption = matterDocument.Document.Name;
    if (closeParentWindow)
    {
        //If Earlier Window/ Document Could be closed. Then need to invoke Close
        Word._Document docToClose = Application.Documents[activeDocName] as Word._Document;
        docToClose.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
    }
