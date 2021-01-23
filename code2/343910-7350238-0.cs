    private Bitmap bmp = new Bitmap(256, 256);
    private void Form1_Load(object sender, EventArgs e)
    {
      pictureBox1.Image = bmp;
    }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      TextBox txt = new TextBox();
      txt.Location = e.Location;
      txt.Width = 120;
      txt.Leave += new EventHandler(txt_Leave);
      pictureBox1.Controls.Add(txt);
    }
    void txt_Leave(object sender, EventArgs e)
    {
      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.DrawString(((TextBox)sender).Text, ((TextBox)sender).Font, Brushes.Black, ((TextBox)sender).Location);
      }
      ((TextBox)sender).Leave -= new EventHandler(txt_Leave);
      pictureBox1.Controls.Remove((TextBox)sender);
      ((TextBox)sender).Dispose();
      pictureBox1.Invalidate();
    }
