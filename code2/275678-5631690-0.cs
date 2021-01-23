    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyChar == ',')
        {
           if(TextBox.Text.Contains(",,"))
           {
               e.Handled = true;
           }
        }
    }
