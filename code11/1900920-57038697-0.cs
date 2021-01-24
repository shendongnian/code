     // Add paragraph before table
    var rangeBeforeTable = document.Bookmarks.get_Item(@"\EndOfDoc").Range;
    rangeBeforeTable.InsertParagraphAfter();
    
    // Add table
    var newTableRange = document.Bookmarks.get_Item(@"\EndOfDoc").Range;
    document.Content.Paragraphs.Add(newTableRange);
    var newTable = document.Tables.Add(newTableRange, 1, 1, ref oMissing, ref oMissing);
    newTable.Range.Paste();
    
    // Save coordinates
    int leftOriginal, topOriginal, widthOriginal, heightOriginal;
    int left, top, width, height;
    
    // Get coordinates from newly created table
    word.ActiveWindow.GetPoint(out leftOriginal, out topOriginal, out widthOriginal, out heightOriginal, newTableRange);
    
    while (true)
    {
    	// Get coordinates from moving table
    	word.ActiveWindow.GetPoint(out left, out top, out width, out height, newTableRange);
    
    	if (top < topOriginal)
    	break;
    
    	// Add paragraph before new table and move table down
    	document.Content.Paragraphs.Add(newTableRange.Previous());
    }
