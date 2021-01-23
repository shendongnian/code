    private void CB_TextChanged(object sender, EventArgs e)
    {
      try
      {
        CB.TextChanged -= CB_TextChanged;	// Don't respond to text changes from within this function
        int start = CB.SelectionStart;		// Where did user enter new text?
        int length = CB.SelectionLength;	// How much text did they enter?
        if (start > 0) length += start;		// Always consider text from beginning of string
        string text = CB.Text.Substring(0, length);	// Look at start of text
        foreach (string item in CB.Items)
        {
          if (item.StartsWith(text, StringComparison.OrdinalIgnoreCase))
          {
            // If the typed text matches one of the items in the list, use that item
            // Highlight the text BEYOND where the user typed, to the end of the string
            // That way, they can keep on typing, replacing text that they have not gotten to yet
            CB.Text = item;
            CB.SelectionStart = length;
            CB.SelectionLength = item.Length - length;
            break;
          }
        }
      }
      finally
      {
        CB.TextChanged += CB_TextChanged;  // Restore ability to respond to text changes
      }
    }
