    private void btn1_CheckedChanged(object sender, EventArgs e)
    {
      btn2.CheckedChanged -= btn2_CheckedChanged;
      btn2.Checked = false;
      btn2.CheckedChanged += btn2_CheckedChanged;
    
        // Do some staff
    }
    
    private void btn2_CheckedChanged(object sender, EventArgs e)
    {
      btn1.CheckedChanged -= btn1_CheckedChanged;
      btn1.Checked = false;
      btn1.CheckedChanged += btn1_CheckedChanged;
    
        // Do another staff
    }
