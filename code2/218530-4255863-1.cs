    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
     //Create a new pen to draw the arrow with
     using (Pen p = new Pen(Brushes.Green, 4f))
     {
      //Specify the EndCap, because we're drawing a right-facing arrow
      p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
    
      //Draw the arrow
      e.Graphics.DrawLine(p, 0, 0, 30, 45);
     }
    }
