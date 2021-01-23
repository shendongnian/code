    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = true;
        Button1.CausesValidation = true;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Button1.CausesValidation = false;
        TextBox1.Enabled = false;
    }
