    private void textBox1_TextChanged(object sender, EventArgs e)
    		{
    			if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
    			{
    				button1.Enabled = true;
    			}
    		}
