    private void myTextBox_TextChanged(object sender, EventArgs e) {
      // When pasting a text into myTextBox...
      TextBox box = sender as TextBox;
      
      StringBuilder sb = new StringBuilder(box.Text.Length);
      bool containsMinus = false;
      // We remove all '-' but the very first one
      foreach (char ch in box.Text) {
        if (ch == '-') {
          if (containsMinus)
            continue;
          containsMinus = true;
        }
        sb.Append(ch);
      }
      box.Text = sb.ToString();
    }
    private void myTextBox_KeyPress(object sender, KeyPressEventArgs e) {
      TextBox box = sender as TextBox;
      // we allow all characters ...
      e.Handled = e.KeyChar == '-' &&             // except '-'
                  box.Text.Contains('-') &&       // when we have '-' within Text
                 !box.SelectedText.Contains('-'); // and we are not going to remove it
    }
