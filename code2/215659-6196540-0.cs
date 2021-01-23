    ...
    mySplitContainer.Paint += CustomPaint.PaintSplitterWithHandle;
    ...
    public static class CustomPaint {
      public static void PaintSplitterWithHandle(object sender, PaintEventArgs p) {
        SplitContainer splitter = sender as SplitContainer;
        if (splitter == null) return;
        if (splitter.Orientation == Orientation.Horizontal)
            p.Graphics.DrawLine(Pens.DarkGray, 
               0, splitter.SplitterDistance + (splitter.SplitterWidth / 2),
               splitter.Width, splitter.SplitterDistance + (splitter.SplitterWidth / 2));
        else
            p.Graphics.DrawLine(Pens.DarkGray, 
                splitter.SplitterDistance + (splitter.SplitterWidth / 2), 0,
                splitter.SplitterDistance + (splitter.SplitterWidth / 2), splitter.Height);
      }
    }
