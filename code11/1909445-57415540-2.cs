        ..
        InitializeComponent();
        Size sz = tableLayoutPanel1.Size;
        drawings.Add(
          new DrawAction(Point.Empty, new Point(sz.Width, sz.Height), Color.Red, 0));
        drawings.Add(
          new DrawAction(new Point(0, sz.Height), new Point(sz.Width, 0), Color.Blue, 0));
        drawings.Add(
          new DrawAction(new Point(50, 50), new Point(300, 300), Color.Green, 1));
        initPainting(tableLayoutPanel1, tableLayoutPanel1);
