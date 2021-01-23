    protected override Size MeasureOverride(Size availableSize)
    {
        var requiredSize = new Size();
    
        double allItemsHeight = 0;
    
        foreach (UIElement e in InternalChildren)
        {
            e.Measure(new Size(availableSize.Width, double.PositiveInfinity));
            allItemsHeight += e.DesiredSize.Height;
        }
    
        double scale = 1;
    
        if (allItemsHeight > availableSize.Height)
        {
            scale = availableSize.Height / allItemsHeight;
        }
    
        foreach (UIElement e in InternalChildren)
        {
            double height = e.DesiredSize.Height * scale;
    
            e.Measure(new Size(availableSize.Width, height));
    
            requiredSize.Height += e.DesiredSize.Height;
            requiredSize.Width = Math.Max(requiredSize.Width, e.DesiredSize.Width);
        }
    
        return new Size(
            Math.Min(availableSize.Width, requiredSize.Width),
            Math.Min(availableSize.Height, requiredSize.Height));
    }
 
