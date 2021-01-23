    public class CustomPanel : StackPanel
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            var childUIElements = Children.OfType<UIElement>().ToList();
            foreach (var child in childUIElements)
            {
                child.Measure(finalSize);
            }
            double remainingHeight = finalSize.Height - childUIElements.Sum(c => c.DesiredSize.Height);
            if(remainingHeight <= 0)
                return base.ArrangeOverride(finalSize);
            double yOffset = 0;
            foreach (var child in childUIElements)
            {
                double height = child.DesiredSize.Height + remainingHeight/childUIElements.Count;
                child.Arrange(new Rect(0,yOffset,finalSize.Width,height));
                yOffset += height;
            }
            return finalSize;
        }
    }
