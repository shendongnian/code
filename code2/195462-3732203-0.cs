    public void radio_OnCheckChanged(object sender, EventArgs e)
    {
       RadioButton r = sender as RadioButton;
       bool isUserChange = r.Tag.Equals(1);
       if (isUserChange) blabla
       else blabla
       r.Tag = null;       
    }
    
    public void MyMethod()
    {
       radio1.Tag = 1;
       radio.Checked = true;
    }
