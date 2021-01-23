    Boolean UserDoneUpdating = false;
    
    private void MytrackBar_ValueChanged(object sender, EventArgs e)
    {
    	UserDoneUpdating = true;
    }
    
    private void MytrackBar_MouseUp(object sender, MouseEventArgs e)
    {
    	if (UserDoneUpdating)
    		Do_Stuff();
    }
