    void GotoLine(int wantedLine_zero_based) // int wantedLine_zero_based = wanted line number; 1st line = 0
    {
    	int index = this.RichTextbox.GetFirstCharIndexFromLine(wantedLine_zero_based);
    	this.RichTextbox.Select(index, 0);
        this.RichTextbox.ScrollToCaret();
    }
