        if (doc.Bookmarks.Exists(name))
        {
           Word.Bookmark bm = doc.Bookmarks[name];
           Word.Range range = bm.Range.Duplicate;
           bm.Range.Text = text;                   // Bookmark is deleted, range is collapsed
           range.End = range.Start + text.Length;  // Reset range bounds
           doc.Bookmarks.Add(name, range);         // Replace bookmark
        }
