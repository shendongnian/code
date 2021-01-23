    private void ToolStripDropDownButton1_Paint(object sender, PaintEventArgs e)
    {
    	e.Graphics.FillRectangle(Brushes.Chartreuse,
                                 e.ClipRectangle.X + 3, e.ClipRectangle.Y + 3,
                                 e.ClipRectangle.Width - 12,
                                 e.ClipRectangle.Height - 12);
    }
