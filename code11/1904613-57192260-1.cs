    Color backColor = (GetTopNodeIndex(e.Node) & 1) == 0 ? BackColor : AlternateBackColor;
    using (Brush b = new SolidBrush(backColor))
    {
      e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
    }
    if ((e.State & TreeNodeStates.Selected) != 0) {
      e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
    }
