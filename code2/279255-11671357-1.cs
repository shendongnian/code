    Boolean user_done_updating = false;
    
    private void MytrackBar_ValueChanged(object sender, EventArgs e)
    {
    	user_done_updating = true;
    }
    
    private void MytrackBar_MouseUp(object sender, MouseEventArgs e)
    {
    	if (user_done_updating)
    	{
    		user_done_updating = false;
    		//Do Stuff
    	}
    }
