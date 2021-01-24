    private void Form1_Load(object sender, EventArgs e)
    {
        ButtonEnabler();
    }
    private void txtPrice_TextChanged(object sender, EventArgs e)
    {
        ButtonEnabler();
    }
    private void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        ButtonEnabler();
    }
    private void ButtonEnabler()
    {
        bool enabled = txtPrice.TextLength + txtQuantity.TextLength > 0;
        btnCalculate.Enabled = enabled;
        btnMessageBox.Enabled = enabled;
    }
