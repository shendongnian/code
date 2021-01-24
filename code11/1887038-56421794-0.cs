    private void textBox_TextChanged(object sender, EventArgs e)
    {
    	TextBox tb = sender as TextBox;
    	if (tb != null && !string.IsNullOrWhiteSpace(tb.Text))
    	{
    		tb.Text = tb.Text.Remove(0, 6).PadLeft(10, '#');
    	}
    } 
   
