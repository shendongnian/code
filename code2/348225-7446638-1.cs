    Word.Application app = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    if (app == null)
        return true;
    foreach (Word.Document d in app.Documents)
    {
        if (d.FullName.ToLower() == osPath.ToLower())
        {
            object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
            object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;
            d.Close(ref saveOption, ref originalFormat, ref routeDocument);
            return true;
        }
    }
    return true;
