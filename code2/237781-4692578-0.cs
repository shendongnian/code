    foreach (Control c in parent.Controls)
    {
    	var tb = c as TextBox;
            if (tb != null)
            {
           	//do your validation	
    		    if (string.IsNullOrEmpty(tb.Text))
    		    {
    		        tb.ForeColor = Color.Red
    		    }
            }
                
    }
