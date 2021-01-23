    private IAsyncResult BeginAsyncOperation(object sender, EventArgs e, AsyncCallback callback, object state)
    {
        var t = new ThreadStart(GetData);
     	return t.BeginInvoke(callback, null);
    }
    	
    private void GetData()
    {
        try
        {
            throw new Exception("something broke!");
        }
        catch (Exception ex)
        {
            this.lblError.Text = ex.Message; 
            this.pnlError.Visible = true;
        }
    }
