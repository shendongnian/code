    private void textBox1_Leave(object sender, EventArgs e)
    {
        textBox1.Text = VerifyNumeric(textBox1.Text);
    }
    private string VerifyNumeric(string text)
    {
        double value = 0;
        double.TryParse(text, out value);
        return value.ToString(); // could format here too.
    }
