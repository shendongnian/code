    void textBox_MouseClick(object sender, MouseEventArgs e)
    {
        textBox tb = (TextBox)sender;
        if (checkBox1.IsChecked)
        {
            tb.Text = "";
        }
        else
        {
            tb.Text = Clipboard.GetText();
        }
    }
