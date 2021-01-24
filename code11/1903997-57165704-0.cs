c#
private void TextBox1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyData == (Keys.Shift | Keys.Enter))
    {
        int pos = textBox1.SelectionStart;
        textBox1.SelectedText = Environment.NewLine;
        textBox1.SelectionStart = pos + 2;
        e.Handled = e.SuppressKeyPress = true;
        return;
    }
    if (e.KeyCode == Keys.Enter)
    {
        MessageBox.Show("Hello");
        e.SuppressKeyPress = true;
    }
}
In this code you changed "e.SuppressKeyPress" but events on the window have already processed your input.
c#
private bool test = false;
private void TextBox1_TextChanged(object sender, EventArgs e)
{
    if (test)
    {
        test = false;
        textBox1.Text += "Test";
    }
}
private void TextBox1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyData == (Keys.Shift | Keys.Enter))
    {
        int pos = textBox1.SelectionStart;
        textBox1.SelectedText = Environment.NewLine;
        textBox1.SelectionStart = pos + 2;
        e.Handled = e.SuppressKeyPress = true;
        return;
    }
    if (e.KeyCode == Keys.Enter)
    {
        test = true;
        MessageBox.Show("Hello");
        e.SuppressKeyPress = true;
        test = false;
    }
}
It can be checked through the corresponding code.
If you type "Enter" "Test" is added to textbox
c#
private void TextBox1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyData == (Keys.Shift | Keys.Enter))
    {
        int pos = textBox1.SelectionStart;
        textBox1.SelectedText = Environment.NewLine;
        textBox1.SelectionStart = pos + 2;
        e.Handled = e.SuppressKeyPress = true;
        return;
    }
    if (e.KeyCode == Keys.Enter)
    {
        this.BeginInvoke(new Action(() =>
        {
            MessageBox.Show("Hello");
        }));
        e.SuppressKeyPress = true;
    }
}
You can use BeginInvoke
