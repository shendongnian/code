    public class MyCanvas : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);
            var size = new Size();
            foreach (var child in Children.OfType<FrameworkElement>())
            {
                var x = GetLeft(child) + child.Width;
                var y = GetTop(child) + child.Height;
                if (!double.IsNaN(x) && size.Width < x)
                {
                    size.Width = x;
                }
                if (!double.IsNaN(y) && size.Height < y)
                {
                    size.Height = y;
                }
            }
            return size;
        }
    }
