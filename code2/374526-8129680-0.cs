    private void textBox1_KeyDown(object sender, KeyEventArgs e) {
      bool numOK = ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 ||
                     e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) &&
                     e.Modifiers != Keys.Shift);
      bool editOK = ((e.Control && e.KeyCode == Keys.V) ||
                     (e.Control && e.KeyCode == Keys.C) ||
                     (e.Control && e.KeyCode == Keys.X) ||
                     (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back));
      bool moveOK = (e.KeyCode == Keys.Up ||
                     e.KeyCode == Keys.Right ||
                     e.KeyCode == Keys.Down ||
                     e.KeyCode == Keys.Left ||
                     e.KeyCode == Keys.Home ||
                     e.KeyCode == Keys.End);
      if (!(numOK || editOK || moveOK)) {
        e.SuppressKeyPress = true;
        e.Handled = true;
      }
    }
