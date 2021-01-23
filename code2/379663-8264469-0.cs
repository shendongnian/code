    public class MyForm : Form
    	...
    	private Rectangle? _boxRectangle;	
    	
    	private void OnMyButtonClick(object sender, EventArgs e)
    	{
    		if (button1.Text == "Start")
    		{
    			_boxRectangle = new Rectangle(...);
    			button1.Text = "Stop";
    		}
    		else
    		{
    			_boxRectangle = null;
    			button1.Text = "Start";
    		}
    		Invalidate(); // repaint
    	}
    	
    	protected override OnPaint(PaintEventArgs e)
    	{
    		if (_boxRectangle != null)
    		{
    			Graphics g = e.Graphics.
    			Pen pen = new Pen(Color.DarkBlue);
    			g.DrawRectangle(_boxRectangle);
    		}
    	}
    }
