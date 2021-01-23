    private void btnSubmit_Click(Object sender, System.EventArgs e)
    {
        foreach (Control c in form1.Controls) 
        {            
            if (c.HasControls())
            {
                foreach (Control child in c)
                {
                    //Access Child controls here
                }
            }
        }
    }
