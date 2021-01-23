    private void inBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Return)
      {
        button1.PerformClick();
        e.Handled = true;
      }
    }
