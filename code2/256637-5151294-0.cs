	public class Form1
	{
	Rectangle mRect;
	
		public Form1()
		{
			this.DoubleBuffered = true;
		}
	
		protected override OnMouseDown(MouseEventArgs e)
		{
			mRect = New Rectangle(e.X, e.Y, 0, 0)
			this.Invalidate();
		}
	
		protected override OnMouseMove(MouseEventArgs e)
		{
			if( e.Button = Windows.Forms.MouseButtons.Left)
			{
				mRect = New Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - mRect.Top);
				this.Invalidate();
			}
		}
	
		protected override OnPaint(PaintEventArgs e)
		{
		using(Pen pen = New Pen(Color.Red, 2)
		{
			e.Graphics.DrawRectangle(pen, mRect);
		}
		
		}
	}
