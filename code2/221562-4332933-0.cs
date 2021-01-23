    private void myTabControl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	//Check to see if an arrow key was pressed
    	if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
    	{
    		//Cancel the keypress by indicating it was handled
    		e.Handled = true;
    	}
    }
