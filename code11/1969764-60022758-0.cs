    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
    	// Starting point of the selection:
    	if (e.Button == MouseButtons.Left)
    	{
    		_selecting = true;
    		_selection = new Rectangle(new Point(e.X, e.Y), new Size());
    		_startingPoint = e.Location;
    	}
    }
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
    	// Update the actual size of the selection:
    	if (_selecting)
    	{
    		UpdateRectange(e.Location);
    	}
    }
    		
    private void UpdateRectange(Point newPos)
    {
    	var diffX = newPos.X - _startingPoint.X;
    	var diffY = newPos.Y - _startingPoint.Y;
    	var newSize = new Size(Math.Abs(diffX), Math.Abs(diffY));
    	if (diffX > 0 && diffY > 0)
    	{
    		_selection = new Rectangle(_startingPoint, newSize);
    	}
    	else if (diffX < 0 && diffY < 0)
    	{
    		_selection = new Rectangle(newPos, newSize);
    	}
    	else if (diffX > 0 && diffY < 0)
    	{
    		_selection = new Rectangle(new Point(_startingPoint.X, _startingPoint.Y + diffY), newSize);
    	}
    	else
    	{
    		_selection = new Rectangle(new Point(_startingPoint.X + diffX, _startingPoint.Y), newSize);
    	}
    	uxScreenGrab.Invalidate();
    }
