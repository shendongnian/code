    protected void RadioButton1_30_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;        
        string txtVal = rb.Text;
        string groupName= rb.GroupName;
        int tmpInt;
        Int32.TryParse(txtVal, out tmpInt);
        
    }
