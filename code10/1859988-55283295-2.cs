    private void btnContact_Click(object sender, EventArgs e)
    {
        // Input variables   
        string emailpattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,}$";    
       
        if (GetEmail(ref emailpattern))
        {        
            string msg = string.Format(format, quantity, name, emailpattern, phonepattern, contactDate, method);
            MessageBox.Show(msg, Application.ProductName);
            Close();
        }
    }
    
    private bool GetEmail(ref string emailpattern)
    {  
    	emailpattern = txtEmail.Text;
    	success = true;    
        return success;
    }
