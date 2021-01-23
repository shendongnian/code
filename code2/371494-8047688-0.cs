    public bool EndOfStream
    {
    	get
    	{
    		if (this.stream == null)
    		{
    			__Error.ReaderClosed();
    		}
    		if (this.charPos < this.charLen)
    		{
    			return false;
    		}
    		int num = this.ReadBuffer();
    		return num == 0;
    	}
    }
