    class DrawingArea : Canvas
    {
      static DrawingArea()
      {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DrawingArea), new FrameworkPropertyMetadata(typeof(DrawingArea)));
      }
    
      public DrawingArea()
      {
        this.TemporaryDrawingLine = new Line();
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
          this.Children.Remove(this.TemporaryDrawingLine);
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
        this.StartObject = linkedItem;
        this.TemporaryDrawingLine = new Line()
        {
          X1 = this.StartObject.CurrentPosition.X, Y1 = this.StartObject.CurrentPosition.Y,
          X2 = e.GetPosition(this).X, Y2 = e.GetPosition(this).Y,
          StrokeDashArray = new DoubleCollection() { 5, 1, 1, 1}
        };
        this.Children.Add(this.TemporaryDrawingLine);
      }
    
    
      /// <inheritdoc />
      protected override void OnPreviewMouseMove(MouseEventArgs e)
      {
        Focus();
        if (!this.IsDrawing)
        {
          return;
        }
    
        this.TemporaryDrawingLine.X2 = e.GetPosition(this).X;
        this.TemporaryDrawingLine.Y2 = e.GetPosition(this).Y ;
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
          this.Children.Remove(this.TemporaryDrawingLine);
          this.IsDrawing = false;
          return;
        }
    
        e.Handled = true;
        this.Children.Remove(this.TemporaryDrawingLine);
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
    
      public bool IsDrawing { get; set; }
      private Node EndObject { get; set; }  
      private Node StartObject { get; set; }  
      private Line TemporaryDrawingLine { get; set; }    
    
      #endregion
    }
