    class DrawingArea : Canvas
    {
      static DrawingArea()
      {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DrawingArea), new FrameworkPropertyMetadata(typeof(DrawingArea)));
      }
    
      public DrawingArea()
      {
        this.CurrentDrawingLine = new Line();
      }
    
      #region Overrides of UIElement
    
      /// <inheritdoc />
      protected override void OnPreviewKeyDown(KeyEventArgs e)
      {
        base.OnKeyDown(e);
        if (e.Key.HasFlag(Key.LeftCtrl) || e.Key.HasFlag(Key.RightCtrl))
        {
          this.IsDrawing = true;
        }
      }
    
      /// <inheritdoc />
      protected override void OnPreviewKeyUp(KeyEventArgs e)
      {
        base.OnKeyDown(e);
        if (e.Key.HasFlag(Key.LeftCtrl) || e.Key.HasFlag(Key.RightCtrl))
        {
          this.IsDrawing = false;
          this.Children.Remove(this.CurrentDrawingLine);
        }
      }
    
      /// <inheritdoc />
      protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
      {
        base.OnMouseLeftButtonDown(e);
        if (!this.IsDrawing)
        {
          return;
        }
    
        if (!(e.Source is Node linkedItem))
        {
          return;
        }
        e.Handled = true;
        this.StartObject = linkedItem;
        this.CurrentDrawingLine = new Line()
        {
          X1 = this.StartObject.CurrentPosition.X, Y1 = this.StartObject.CurrentPosition.Y,
          X2 = e.GetPosition(this).X, Y2 = e.GetPosition(this).Y
        };
        this.Children.Add(this.CurrentDrawingLine);
      }
    
    
      /// <inheritdoc />
      protected override void OnPreviewMouseMove(MouseEventArgs e)
      {
        Focus();
        if (!this.IsDrawing)
        {
          return;
        }
        e.Handled = true;
    
        this.CurrentDrawingLine.X2 = e.GetPosition(this).X;
        this.CurrentDrawingLine.Y2 = e.GetPosition(this).Y ;
      }
    
      /// <inheritdoc />
      protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
      {
        base.OnPreviewMouseLeftButtonUp(e);
        if (!this.IsDrawing)
        {
          return;
        }
    
        if (!(e.Source is Node linkedItem))
        {
          this.Children.Remove(this.CurrentDrawingLine);
          this.IsDrawing = false;
          return;
        }
    
        e.Handled = true;
        this.Children.Remove(this.CurrentDrawingLine);
        var line = new Line();
        var x1Binding = new Binding("CurrentPosition.X") {Source = this.StartObject};
        var y1Binding = new Binding("CurrentPosition.Y") { Source = this.StartObject };
        line.SetBinding(Line.X1Property, x1Binding);
        line.SetBinding(Line.Y1Property, y1Binding);
    
        this.EndObject = linkedItem;
        var x2Binding = new Binding("CurrentPosition.X") { Source = this.EndObject };
        var y2Binding = new Binding("CurrentPosition.Y") { Source = this.EndObject };
        line.SetBinding(Line.X2Property, x2Binding);
        line.SetBinding(Line.Y2Property, y2Binding);
        this.Children.Add(line);
        this.IsDrawing = false;
      }
    
      public Node EndObject { get; set; }
    
      public Line CurrentDrawingLine { get; set; }
      public Node StartObject { get; set; }
    
      public bool IsDrawing { get; set; }
    
      #endregion
    }
