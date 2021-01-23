    private void btnOk_Click(object sender, EventArgs e)
    {
        btnOk.Enable = false;
        try
        {
	        // do stuff
        }
        finally
        {
            btnOk.Enable = true;
        }
    }
