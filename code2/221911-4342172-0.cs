    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
    	{
    		e.Handled = true;
    	}
    }
