    private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (!System.Text.RegularExpressions.Regex.IsMatch(textbox1.Text, @"^[a-zA-Z]+$"))
              e.Handled = true;
    }
