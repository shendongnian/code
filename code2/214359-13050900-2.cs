    public class ScrollablePanel : StackPanel
    {
        protected override Size MeasureOverride(Size constraint)
        {
            Size tmpSize = base.MeasureOverride(constraint);
            tmpSize.Height = (double)(this.Children[0] as UIElement).GetValue(MinHeightProperty);
            return tmpSize;
        }
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
        {
            Size tmpSize = new Size(0, 0);
            //Width stays the same
            tmpSize.Width = finalSize.Width;
            
            //Height is changed
            tmpSize.Height = finalSize.Height;
            //This works only for one child!
            this.Children[0].SetCurrentValue(HeightProperty, tmpSize.Height);
            this.Children[0].Arrange(new Rect(new Point(0, 0), tmpSize));
            
            return tmpSize;
        }
    }
