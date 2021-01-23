    public int SelectedIndex
    {
    	get
    	{
    		int num = 0;
    		num++;
    		while (num < this.Items.Count)
    		{
    			if (this.Items[num].Selected)
    			{
    				return num;
    			}
    		}
    		return -1;
    	}
    	set
    	{
    		// stuff you don't care about
    		this.ClearSelection();
    		if (value >= 0)
    		{
    			this.Items[value].Selected = true;
    		}
    		
    		// more stuff you don't care about
    	}
    }
