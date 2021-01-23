    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
    	// Call the base class
    	base.OnPaint(e);
    
    	// Create your drawing pen
    	using (Pen p = new Pen(SystemColors.WindowText, 2.0))
    	{
    		// Calculate the position and dimensions of the box
    		Rectangle rect = new Rectangle(10, 10, 30, 30);
    		// Draw the rectangle
    		e.Graphics.DrawRectangle(p, rect);
    	}
    }
