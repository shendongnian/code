    //Be sure to add this reference:
    //Project>Add Reference>.NET tab>Microsoft.Office.Interop.Word
    
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) {
        // split the given URI on the hash sign
        string[] arguments = e.Uri.AbsoluteUri.Split('#');
    
        //open Word App
        Microsoft.Office.Interop.Word.Application msWord = new Microsoft.Office.Interop.Word.Application();
        
        //make it visible or it'll stay running in the background
        msWord.Visible = true;
        
        //open the document 
        Microsoft.Office.Interop.Word.Document wordDoc = msWord.Documents.Open(arguments[0]);
        
        //find the bookmark
        string bookmarkName = arguments[1];
        
        if (wordDoc.Bookmarks.Exists(bookmarkName))
        {
            Microsoft.Office.Interop.Word.Bookmark bk = wordDoc.Bookmarks[bookmarkName];
        
            //set the document's range to immediately after the bookmark.
            Microsoft.Office.Interop.Word.Range rng = wordDoc.Range(bk.Range.End, bk.Range.End);
        
            // place the cursor there
            rng.Select();
        }
        e.Handled = true;
    }
