    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back)
        { 
            e.Handled = true; 
        }
        //Edit: Alternative
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        {
            e.Handled = true;
        }
    }
