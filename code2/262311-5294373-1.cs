    private void inBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        button1.PerformClick();
        e.Handled = true;
      }
    }
