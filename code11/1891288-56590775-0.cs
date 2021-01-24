    private void button1_Click(object sender, EventArgs e)
    {
    	try
    	{
    		if (listBox1.SelectedIndex == -1)
    		{
    			MessageBox.Show("now item has been seleced");
    		}
    		else
    		{
    			MessageBox.Show(listBox1.SelectedItem.ToString());
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message.ToString());
    		throw;
    	}
    }
