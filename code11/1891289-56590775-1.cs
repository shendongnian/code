    private void button1_Click(object sender, EventArgs e)
    {
    	try
    	{
    		MessageBox.Show(listBox1.SelectedItem.ToString());
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message.ToString());
    		throw;
    	}
    }
