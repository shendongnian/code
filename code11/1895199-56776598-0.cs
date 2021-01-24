	// assuming you're all doing this directly in your main form, as a simple experimental app:
	// Somewhere in your form class:
	Bitmap drawingBitmap;
	Graphics gfx;
	// in your form class' constructor, AFTER the InitializeComponent() call, so the sizes are known:
	// using a pixelformat which usually yields good speed vs. non-premultiplied ones
	drawingBitmap = new Bitmap( pnl.Width, pnl.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb );
	gfx = Graphics.FromImage( drawingBitmap );
	private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
	{
		if(startPaint)
		{
			//Setting the Pen BackColor and line Width
			Pen p = new Pen(btn_PenColor.BackColor,float.Parse(cmb_PenSize.Text));
			//Drawing the line.
			var p1 = new Point(initX ?? e.X, initY ?? e.Y);
			var p2 = new Point(e.X, e.Y);
			gfx.DrawLine( p, p1, p2 ); // !!! NOTE: gfx instance variable is used
			initX = e.X;
			initY = e.Y;
			// makes the panel's Paint handler being called soon - with a clip rectangle just covering your new little drawing stroke, not more.
			pnl.Invalidate( new Rectangle( p1.X, p1.Y, 1+p2.X-p1.X, 1+p2.Y-p1.Y ));
		}
	}
		
	private void pnl_Paint(object sender, Graphics g)
	{
		// use the clip bounds of the Graphics object to draw only the relevant area, not always everything.
		var sourceBounds = new RectangleF( g.ClipRectangle.X, g.ClipRectangle.Y, g.ClipRectangle.Width, g.ClipRectangle.Height );
		
		// The bitmap and drawing panel are assumed to have the same size, to make things easier for this example.
		// Actually you might want have a drawing bitmap of a totally unrelated size, and need to apply scaling to a setting changeable by the user.
		g.DrawImage( drawingBitmap, g.ClipRectangle.X, g.ClipRectangle.Y, sourceBounds );
	}
