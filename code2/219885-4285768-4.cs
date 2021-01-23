    private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z]+$"))
              e.Handled = true;
    }
