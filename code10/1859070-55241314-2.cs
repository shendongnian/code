    public class VisualHost : FrameworkElement
    {
      private VisualCollection Children { get; set; }
      
      public VisualHost()
      {
        this.Children = new VisualCollection(this);
        Visibility = Visibility.Visible;
        IsHitTestVisible = true;
        MouseLeftButtonUp += MyVisualHost_MouseLeftButtonUp;
      }
    
      public void AddChild(Visual visual)
      {
        this.Children.Add(visual);
      }
    
      protected override int VisualChildrenCount => this.Children.Count;
    
      protected override Visual GetVisualChild(int index) => this.Children[index];
    
      //mouse event
      private void MyVisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
        // Initiate the hit test by setting up a hit test result callback method.
        VisualTreeHelper.HitTest(this, null, OnVisualClicked, new PointHitTestParameters(e.GetPosition((UIElement) sender)));
      }
    
      private HitTestResultBehavior OnVisualClicked(HitTestResult result)
      {
        if (result.VisualHit.GetType() == typeof(DrawingVisual))
        {
          MessageBox.Show("You clicked a drawing-Visual");   
        }
    
        // Stop the hit test enumeration of objects in the visual tree.
        return HitTestResultBehavior.Stop;
      }
    }
