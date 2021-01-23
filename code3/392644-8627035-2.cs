    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        {
            if (e.KeyChar != '.')
                e.Handled = true;
            bool hasDecimal = textBox1.Text.Contains('.');
            if (hasDecimal)
                e.Handled = true; // disallow multiple decimal points
        }
    } 
