    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = RequiredFieldValidator1.Enabled = true;
    }
    
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = RequiredFieldValidator1.Enabled = false;
    }
