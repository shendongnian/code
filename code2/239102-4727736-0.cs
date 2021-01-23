    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //get current Date/Time
        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();
    
        //set it to labelDate
        lblDate.Text = "Requested on " + dateTime; 
    
     ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "window.print();", true);
    
    }
   
