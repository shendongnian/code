    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
    	base.OnPaint(e);
    	Point centerPoint = new Point(SplitterRectangle.Left - 1 + SplitterRectangle.Width / 2, SplitterRectangle.Top - 1 + SplitterRectangle.Height / 2);
    	e.Graphics.FillEllipse(SystemBrushes.ControlText, centerPoint.X, centerPoint.Y, 3, 3);
    	if (Orientation == System.Windows.Forms.Orientation.Horizontal) {
    		e.Graphics.FillEllipse(SystemBrushes.ControlText, centerPoint.X - 10, centerPoint.Y, 3, 3);
    		e.Graphics.FillEllipse(SystemBrushes.ControlText, centerPoint.X + 10, centerPoint.Y, 3, 3);
    	} else {
    		e.Graphics.FillEllipse(SystemBrushes.ControlText, centerPoint.X, centerPoint.Y - 10, 3, 3);
    		e.Graphics.FillEllipse(SystemBrushes.ControlText, centerPoint.X, centerPoint.Y + 10, 3, 3);
    	}
    }
