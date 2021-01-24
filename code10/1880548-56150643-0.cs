    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        dateTimePicker2.Enabled=false;
        dateTimePicker3.Enabled = false;
        dateTimePicker4.Enabled = false;
        
    }
        
    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        
        dateTimePicker1.Enabled=false;
        dateTimePicker3.Enabled = false;
        dateTimePicker4.Enabled = false;
        
           
    }
