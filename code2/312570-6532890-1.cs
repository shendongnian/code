    void Label_OnPaint(object sender, PaintEventArgs e) {
      base.OnPaint(e);
      Label lbl = sender as Label;
      if (lbl != null) {
        string Text = lbl.Text;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        if (myShowShadow) { // draw the shadow first!
          e.Graphics.DrawString(Text, lbl.Font, new SolidBrush(myShadowColor), myShadowOffset, StringFormat.GenericDefault);
        }
        e.Graphics.DrawString(Text, lbl.Font, new SolidBrush(lbl.ForeColor), 0, 0, StringFormat.GenericDefault);
      }
    }
