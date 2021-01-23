    //for email validation    
    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
    
    if (txt_email.Text.Length > 0)
    {
    	if (!rEMail.IsMatch(txt_email.Text))
    	{
    		MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		txt_email.SelectAll();
    		e.Cancel = true;
    	}
    }
    
    //for mobile validation    
    Regex re = new Regex("^9[0-9]{9}");
    
    if (re.IsMatch(txt_mobile.Text.Trim()) == false || txt_mobile.Text.Length > 10)
    {
    	MessageBox.Show("Invalid Indian Mobile Number !!");
    	txt_mobile.Focus();
    }
