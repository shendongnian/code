    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            MessageBox.Show("Hello");
        }
    
        if (e.KeyData == (Keys.Shift | Keys.Enter))
        {
            textBox1.SelectedText = "\n";
            e.SuppressKeyPress = true;
        }
    }
