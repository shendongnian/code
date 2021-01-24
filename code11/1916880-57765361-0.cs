    Document doc = appointmentItem.GetInspector.WordEditor as 
    Microsoft.Office.Interop.Word.Document;
    Bookmark bmkFound = doc.Bookmarks.get_Item("bmkToClean");
    Range bmkFound = bmkFound.Range;
    Find find = bmkFound.Find;
    find.Text = "\r";
    find.Replacement.Text = "";
    find.Forward = true;
    find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
    find.Replacement.Text = "";
    find.Execute(Replace: WdReplace.wdReplaceAll);
