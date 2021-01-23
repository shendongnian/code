    public override DocumentPage GetPage(int pageNumber) {
      Canvas container = new Canvas();
      container.Children.Add(canvas);
      double scaleX = pageSize.Width / canvas.Width;
      double scaleY = pageSize.Height / canvas.Height;
      container.RenderTransform = new ScaleTransform(scaleX, scaleY);
    
      container.Width = PageSize.Width;
      container.Height = PageSize.Height;
      container.Measure(PageSize);
      container.Arrange(new Rect(new Point(0, 0), PageSize));
    
      Rect contentBox = new Rect(PageSize);
    
      return new DocumentPage(container, PageSize, contentBox, contentBox);
    }
