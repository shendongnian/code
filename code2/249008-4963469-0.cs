    internal static object GetTag(object sender)
    {
      Button button = sender as Button;
      ToolStripItem tsi = sender as ToolStripItem;
    
      if (button != null)
        return button.Tag;
      if (tsi != null)
        return tsi.Tag;
    
      throw new ArgumentException("Unexpected sender");
    }
