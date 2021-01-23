    private class PanelX : Panel
    {
      protected override CreateParams CreateParams
      {
        get
        {
          CreateParams cp = base.CreateParams;
          cp.ExStyle |= 0x20;
          return cp;
        }
      }
      protected override void OnPaint(PaintEventArgs e)
      {
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
        {
          e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
      }
    }
