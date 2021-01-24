    Color backColor = (GetTopNodeIndex(e.Node) & 1) == 0 ? BackColor : AlternateBackColor;
    if ((e.State & TreeNodeStates.Selected) != 0) {
      e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
    } else {
      using (Brush b = new SolidBrush(backColor))
      {
         e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
      }
    }
