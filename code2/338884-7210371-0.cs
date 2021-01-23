    public partial class MyWrappedControl : UserControl
    {
      public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register("Shapes", typeof(ObservableCollection<IShape>), typeof(MyWrappedControl),
          new PropertyMetadata(null, MyWrappedControl.OnShapesPropertyChanged);
    
      public ObservableCollection<IShape> Shapes
      {
        get { return (ObservableCollection<IShape>)GetValue(ShapesProperty); }
        set { SetValue(ShapesProperty, value); }
      }
    
      private static void OnShapesPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
      {
        ((MyWrappedControl)o).OnShapesPropertyChanged(e);
      }
    
      private void OnShapesPropertyChanged(DependencyPropertyChangedEventArgs e)
      {
        // Do stuff, e.g. shapeDrawer.DrawShapes(); 
      }
    }
