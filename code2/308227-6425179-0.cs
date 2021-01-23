    public void AppendText(string text)
    {
    	if (text.Length > 0)
    	{
    		int start;
    		int length;
    		this.GetSelectionStartAndLength(out start, out length);
    		try
    		{
    			int endPosition = this.GetEndPosition();
    			this.SelectInternal(endPosition, endPosition, endPosition);
    			this.SelectedText = text;
    		}
    		finally
    		{
    			if (base.Width == 0 || base.Height == 0)
    			{
    				this.Select(start, length);
    			}
    		}
    	}
    }
