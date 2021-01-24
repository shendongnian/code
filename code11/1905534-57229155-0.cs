    private void tb_Course_Leave(object sender, EventArgs e) {
      TextBox tb = sender as TextBox;
      if (tb.Text == "")
        return;
      if (int.TryParse(tb.Text, out int value)) {
        if (value >= 0 && value <= 100) {
          return;
        }
      }
      MessageBox.Show("Please enter a VALID number from 1 - 100");
      tb.Text = "";
    }
    private void tb_Course_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !char.IsDigit(e.KeyChar);
    } 
