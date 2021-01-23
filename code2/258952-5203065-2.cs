    public class NewProgressBar : ProgressBar
    {
        //This property takes the Threshold.
        public int Threshold{ get; set; }
    	public NewProgressBar()
    	{
    		this.SetStyle(ControlStyles.UserPaint, true);
    	}
    
    	protected override void OnPaint(PaintEventArgs e)
    	{
    		Rectangle rec = e.ClipRectangle;
    
    		rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
    		if(ProgressBarRenderer.IsSupported)
    		   ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
    		rec.Height = rec.Height - 4;
                //Check value is greater that Threshold
                if(this.Value > Threshold)
                {
            		e.Graphics.FillRectangle(Brushes.Green, 2, 2, rec.Width, rec.Height);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Red, 2, 2, rec.Width, rec.Height);
                }
                //This line should do that
                e.Graphics.DrawLine(Pens.Black,Threshold-1,2,Threshold-1,rec.Height);
    	}
    }
