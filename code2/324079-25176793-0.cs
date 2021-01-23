    /// <summary>
    /// Sets the text and refreshes the control.
    /// </summary>
    /// <param name="text">The text.</param>
    public void SetTextAndRefresh(string text)
    {
    	ResetText();
    	Text = text;
    	Refresh();
    }
