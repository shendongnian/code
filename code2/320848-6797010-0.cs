    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      string header2 = "This is a much, much longer Header";
      string description = "This is a description of the header.";
      RectangleF header2Rect = new RectangleF();
      using (Font useFont = new Font("Gotham Medium", 28, FontStyle.Bold))
      {
        header2Rect.Location = new Point(30, 105);
        header2Rect.Size = new Size(600, ((int)e.Graphics.MeasureString(header2, useFont, 600, StringFormat.GenericTypographic).Height));
        e.Graphics.DrawString(header2, useFont, Brushes.Black, header2Rect);
      }
      RectangleF descrRect = new RectangleF();
      using (Font useFont = new Font("Gotham Medium", 28, FontStyle.Italic))
      {
        descrRect.Location = new Point(30, (int)header2Rect.Bottom);
        descrRect.Size = new Size(600, ((int)e.Graphics.MeasureString(description, useFont, 600, StringFormat.GenericTypographic).Height));
        e.Graphics.DrawString(description.ToLower(), useFont, SystemBrushes.WindowText, descrRect);
      }
    }
