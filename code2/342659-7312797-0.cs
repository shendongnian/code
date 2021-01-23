    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
      else
      {
         MessageBox.Show("Textbox must be numeric only!");
      }
    }
