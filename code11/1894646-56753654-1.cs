    class Node : Thumb
    {
      public static readonly DependencyProperty CurrentPositionProperty = DependencyProperty.Register(
        "CurrentPosition",
        typeof(Point),
        typeof(Node),
        new PropertyMetadata(default(Point)));
    
      public Point CurrentPosition { get { return (Point) GetValue(Node.CurrentPositionProperty); } set { SetValue(Node.CurrentPositionProperty, value); } }
    
      public static readonly DependencyProperty ChildNodesProperty = DependencyProperty.Register(
        "ChildNodes",
        typeof(ObservableCollection<Node>),
        typeof(Node),
        new PropertyMetadata(default(ObservableCollection<Node>)));
    
      public ObservableCollection<Node> ChildNodes { get { return (ObservableCollection<Node>) GetValue(Node.ChildNodesProperty); } set { SetValue(Node.ChildNodesProperty, value); } }
    
      public static readonly DependencyProperty DrawingAreaProperty = DependencyProperty.Register(
        "DrawingArea",
        typeof(DrawingArea),
        typeof(Node),
        new PropertyMetadata(default(DrawingArea)));
    
      public DrawingArea DrawingArea { get { return (DrawingArea) GetValue(Node.DrawingAreaProperty); } set { SetValue(Node.DrawingAreaProperty, value); } }
    
      static Node()
      {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Node), new FrameworkPropertyMetadata(typeof(Node)));
      }
    
      public Node()
      {
        this.DragDelta += MoveOnDragStarted;
      }
    
      private void MoveOnDragStarted(object sender, DragDeltaEventArgs dragDeltaEventArgs)
      {
        if (this.DrawingArea.IsDrawing)
        {
          return;
        }
        this.CurrentPosition = new Point(Canvas.GetLeft(this) + dragDeltaEventArgs.HorizontalChange, Canvas.GetTop(this) + dragDeltaEventArgs.VerticalChange);
      }
    }
