    ...
    private void Rectangle_MouseMove(object sender, MouseEventArgs e)
    {
      if (!floatingTip.IsOpen) { floatingTip.IsOpen = true; }
    
      Point currentPos = e.GetPosition(rect);
    
      // The + 20 part is so your mouse pointer doesn't overlap.
      floatingTip.HorizontalOffset = currentPos.X + 20;
      floatingTip.VerticalOffset = currentPos.Y;
    }
    
    private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
    {
      floatingTip.IsOpen = false;
    }
    ...
