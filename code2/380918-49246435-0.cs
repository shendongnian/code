    using Microsoft.Office.Interop.Word;
    ...
    Application wordApplication = new Application();
    ...
        object paramMissing = Type.Missing;
        object saveOptionsObject = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            wordApplication.Quit(ref saveOptionsObject, ref paramMissing, ref paramMissing);
            wordApplication = null;
