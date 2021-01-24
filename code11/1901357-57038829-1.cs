    System.Text.RegularExpressions
    ...
    private void MyTextBox_KeyPress(object sender, KeyPressEventArgs e) {
      // we don't accept whitespace characters
      if (char.IsWhiteSpace(e.KeyChar)) 
        e.Handled = true;
    }
    private void MyTextBox_TextChanged(object sender, EventArgs e) {
      // We remove whitespaces from text inserted 
      (sender as TextBox).Text = Regex.Replace((sender as TextBox).Text, @"\s+", "");
    }
