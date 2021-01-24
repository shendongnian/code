    public void clearForm()
    {
    	foreach (Control field in Controls)
    	{
    		if (field is TextBox)
    			((TextBox)field).Clear();
    		else if (field is ListView)
    			((ListView)field).Items.Clear();
    	}
    }
           
