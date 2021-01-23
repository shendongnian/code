    bool isDisabled = true;
    private void comboBox1_Enter(object sender, EventArgs e)
    {
        if(isDisabled)
        {
            comboBox1.Enabled = false;
            comboBox1.Enabled = true;
        }
    }
