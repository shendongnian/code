    object filename = @"C:\Documents and Settings\blah\My Documents\chapters.docx";
    object confirmConversions = false;
    object readOnly = true;
    object visible = true;
    object missing = Type.Missing;
    Application wordApp;
    
    object word;
    try
    {
        word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    catch (COMException)
    {
        Type type = Type.GetTypeFromProgID("Word.Application");
        word = System.Activator.CreateInstance(type);
    }
    
    wordApp = (Application) word;
    wordApp.Visible = true;
    Console.WriteLine("There are {0} documents open.", wordApp.Documents.Count);
    var wordDoc = wordApp.Documents.Open(ref filename, ref confirmConversions, ref readOnly, ref missing,
                                            ref missing, ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref visible,
                                            ref missing, ref missing, ref missing, ref missing);
    wordApp.Activate(); 
    object bookmarkName = "Chapter2";
    if (wordDoc.Bookmarks.Exists(bookmarkName.ToString()))
    {
        var bookmark = wordDoc.Bookmarks.get_Item(bookmarkName);
        bookmark.Select();
    }
