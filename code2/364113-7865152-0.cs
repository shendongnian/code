    public class MyWrapPanel : WrapPanel
    {
        public int MaxRows
        {
          get { return (int)GetValue(MaxRowsProperty); }
          set { SetValue(MaxRowsProperty, value); }
        }
        
        public static readonly DependencyProperty MaxRowsProperty =
        DependencyProperty.Register("MaxRows", typeof(int), typeof(MyWrapPanel), new UIPropertyMetadata(4));
        
        protected override Size ArrangeOverride(Size finalSize)
        {
           Point currentPosition = new Point();
           double ItemMaxHeight = 0.0;
           int RowIndex = 0;
        
           foreach (UIElement child in Children)
           {
              ItemMaxHeight = ItemMaxHeight > child.DesiredSize.Height ? ItemMaxHeight : child.DesiredSize.Height;
        
              if (currentPosition.X + child.DesiredSize.Width > this.DesiredSize.Width)
              {
                 currentPosition = new Point(0, currentPosition.Y + ItemMaxHeight);
                 ItemMaxHeight = 0.0;
                 RowIndex++;
              }
        
             if (RowIndex < MaxRows)
             {
                 child.Visibility = System.Windows.Visibility.Visible;
                 Rect childRect = new Rect(currentPosition, child.DesiredSize);
                 child.Arrange(childRect);
             }
             else
             {
                 Rect childRect = new Rect(currentPosition, new Size(0,0));
                 child.Arrange(childRect);
             }
        
             currentPosition.Offset(child.DesiredSize.Width, 0);
          }
        
          return finalSize;
       }
       
       protected override Size MeasureOverride(Size availableSize)
       {
           return base.MeasureOverride(availableSize);
       }
    
    }
