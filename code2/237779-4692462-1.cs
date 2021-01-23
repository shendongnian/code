    bool validated = Validate(ageTB, nameTB, countryTB, etc);
    if (validated)
    {
        // Save XML
    }
    else
    {
        // Show error
    }
    private bool Validate(params TextBox[] textboxes)
    {
    	foreach (TextBox tb in textboxes)
    	{
    		if (string.IsNullOrEmpty(tb.Text))
    			return false;
    	}
    	
    	return true;
    }
