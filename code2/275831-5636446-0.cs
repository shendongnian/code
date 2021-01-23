    private void myTextBox_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.Control)
       {
          if (e.KeyCode == Keys.R)
          {
             MessageBox.Show("Pressed Ctrl+R");
          }
          else
          {
             MessageBox.Show("Pressed Ctrl");
          }
       }
       else if (e.KeyCode == Keys.Escape)
       {
          MessageBox.Show("Pressed Esc");
       }
    }
