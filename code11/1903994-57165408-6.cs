    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            BeginInvoke(new MethodInvoker(() => MessageBox.Show("Hello")));
        }
    
        if (e.KeyData == (Keys.Shift | Keys.Enter))
        {
            textBox1.SelectedText = "\r\n";
            e.SuppressKeyPress = true;
        }
    }
