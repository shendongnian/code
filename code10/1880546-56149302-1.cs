    private void date1_ValueChanged(object sender, EventArgs e)
            {
    date3.Enabled=false;
    date4.Enabled = false;
            }
    
    private void date2_ValueChanged(object sender, EventArgs e)
            {
    
    date3.Enabled=false;
    date4.Enabled = false;
            }
    
    private void date3_ValueChanged(object sender, EventArgs e)
            {
    date1.Enabled=false;
    date2.Enabled = false;
            }
    
    private void date4_ValueChanged(object sender, EventArgs e)
            {
    
    date1.Enabled=false;
    date2.Enabled = false;
            }
    private void LoadDateFromDB(bool firstSet)
    {
       if(firstSet)
    {
       // Get Values from DB and use the first date pickers
    }
    else
    {
    // Get values from DB and use the second pair of DatePickers
    }
    
    // Finally
    ResetDatePickersState();
    }
    
    private void ResetDatePickersState()
    {
        date1.Enabled=true;
        date2.Enabled = true;
        date3.Enabled=true;
        date4.Enabled = true;
    }
