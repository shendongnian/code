    private void DecimalOnlyField_KeyPress(object sender, KeyPressEventArgs e) {
      if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')) {
        e.Handled = true;
      }
      TextBox txtDecimal = sender as TextBox;
      if (e.KeyChar == '.' && txtDecimal.Text.Contains(".")) {
        e.Handled = true;
      }
    }
    private void IntegerOnlyField_KeyPress(object sender, KeyPressEventArgs e) {
      if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))) {
        e.Handled = true;
      }
    }
