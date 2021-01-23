     /// <summary>
    /// Handles Drop Event for Media Items.
    /// </summary>
    private void Media_Drop(object sender, DragEventArgs e)
    {
        string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) 
            as string[];
        //keep a dictionary of added files
        foreach (string f in fileNames)
        {
            if (IsValidMediaItem(f))
                mediaItems.Add(f.Substring(f.LastIndexOf(@"\")+1),
        new MediaItem(@f,0));
        }
    
        //now add to the list
        foreach (MediaItem mi in mediaItems.Values)
            lstMediaItems.Items.Add(mi);
    
        // Mark the event as handled,
        // so the control's native Drop handler is not called.
        e.Handled = true;
    }
    
    /// <summary>
    /// check to see if dragged items are valid
    /// </summary>
    /// <returns>true if filename is valid</returns>
    private bool IsValidMediaItem(string filename)
    {
        bool isValid = false;
        string fileExtesion = filename.Substring(filename.LastIndexOf("."));
        foreach (string s in MediaItem.allowableMediaTypes)
        {
            if (s.Equals(fileExtesion, 
        StringComparison.CurrentCultureIgnoreCase))
                isValid = true;
        }
        return isValid;
    }
