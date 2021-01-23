    private void button1_Click(object sender, EventArgs e)
    {
      System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(panel1.Handle);
      g.DrawEllipse(Pens.Green, panel1.ClientRectangle);
    }
