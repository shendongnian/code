     private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        MessageBox.Show("LEFT");
      }
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        MessageBox.Show("RIGHT");
      }
    }
