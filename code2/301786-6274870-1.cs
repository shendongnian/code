    private void OnTimerEvent(object sender, EventArgs e)
    
    {
    
        lbl.Text = DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString();
    
    }
