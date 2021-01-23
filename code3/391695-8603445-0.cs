    // Draw the text
    using (StringFormat sf = new StringFormat())
    {
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        sf.HotkeyPrefix = this.ShowKeyboardCues ? HotkeyPrefix.Show : HotKeyPrefix.Hide;
         
        if (this.Enabled)
        {
            using (Brush br = new SolidBrush(this.ForeColor))
            {
                g.DrawString(this.Text, this.Font, br, this.ClientRectangle, sf);
            }
        }
        else
        {
            SizeF sz = g.MeasureString(this.Text, this.Font, Point.Empty, sf);
            RectangleF rc = new RectangleF(Point.Empty, sz);
            ControlPaint.DrawStringDisabled(g, this.Text, this.Font, this.BackColor, rc, sf);
        }
     }
     // Draw the focus rectangle
     if (this.ShowFocusCues && this.ContainsFocus)
     {
         ControlPaint.DrawFocusRectangle(g, this.ClientRectangle);         
     }
