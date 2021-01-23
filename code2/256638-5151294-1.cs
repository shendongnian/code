	public class Form1
	{
               
	       Rectangle mRect;
	
		public Form1()
		{
                        //Improves prformance and reduces flickering
			this.DoubleBuffered = true;
		}
	
                //Initiate rectangle with mouse down event
		protected override OnMouseDown(MouseEventArgs e)
		{
			mRect = New Rectangle(e.X, e.Y, 0, 0)
			this.Invalidate();
		}
	
                //check if mouse is down and being draged, then draw rectangle
		protected override OnMouseMove(MouseEventArgs e)
		{
			if( e.Button = Windows.Forms.MouseButtons.Left)
			{
				mRect = New Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - mRect.Top);
				this.Invalidate();
			}
		}
	
                //draw the rectangle on paint event
		protected override OnPaint(PaintEventArgs e)
		{
                    //Draw a rectangle with 2pixel wide line
		    using(Pen pen = New Pen(Color.Red, 2)
		    {
			e.Graphics.DrawRectangle(pen, mRect);
		    }
		
		}
	}
