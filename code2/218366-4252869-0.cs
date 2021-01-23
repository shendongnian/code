    MouseButtons _lastButtonUp = MouseButtons.None;
    
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
    	_lastButtonUp = e.Button;
    }
    
    private void Form1_DoubleClick(object sender, EventArgs e)
    {
    	switch (_lastButtonUp)
    	{
    		case System.Windows.Forms.MouseButtons.Left:
    			MessageBox.Show("left double click");
    			break;
    		case System.Windows.Forms.MouseButtons.Right:
    			MessageBox.Show("right double click");
    			break;
    		case System.Windows.Forms.MouseButtons.Middle:
    			MessageBox.Show("middle double click");
    			break;
    	}
    	
    }
