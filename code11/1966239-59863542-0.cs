    private void Form1_Load(object sender, EventArgs e)
    {
    	foreach (Control ctl in Controls)
    	{
    		if (ctl.GetType() == typeof(NumericUpDown))
    			ctl.MouseWheel += Ctl_MouseWheel;
    	}
    }
    
    private void Ctl_MouseWheel(object sender, MouseEventArgs e)
    {
    	((HandledMouseEventArgs) e).Handled = true;
    }
