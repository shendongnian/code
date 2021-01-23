    public void Form1_MouseDown(object sender, MouseEventArgs e)
    {
    	if(e.Button != MouseButton.Left)
    		return;
    
    	// Might want to pad these values a bit if the line is only 1px,
    	// might be hard for the user to hit directly
    	if(e.Y == myControl.Top)
    	{
    		if(e.X >= myControl.Left && e.X <= myControl.Left + myControl.Width)
    		{
    			_capturingMoves = true;
    			return;
    		}
    	}
    	
    	_capturingMoves = false;
    }
    
    public void Form1_MouseMove(object sender, MouseEventArgs e) 
    {
    	if(!_capturingMoves)
    		return;
    		
    	// Calculate the delta's and move the line here
    }
    
    public void Form1_MouseUp(object sender, MouseEventArgs e) 
    {
    	if(_capturingMoves)
    	{
    		_capturingMoves = false;
    		// Do any final placement
    	}
    }
