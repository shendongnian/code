      private void textBox1_KeyDown(object sender, KeyEventArgs e)
      {
          if (e.Control && (e.KeyCode == Keys.A))
          {
              if (sender != null)
                   ((TextBox)sender).SelectAll();
              e.Handled = true;
          }
      }
