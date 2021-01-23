    if(Int32.TryParse(sr.ReadToEnd(), out Online))
    {
        if (Build >= Online)
    		{
    				Label10.Visible = true;
    		}
    		else
    		{
    				LinkLabel1.Visible = true;
    		}
    }
    else
    {
    			LinkLabel1.Visible = true;
    }
