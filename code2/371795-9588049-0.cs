    public static UIElement GetMeasuredAndArrangedVisual(UIElement visual)
            {
                visual.Measure(new Size
                {
                    Height = double.PositiveInfinity,
                    Width = double.PositiveInfinity
                });
    
                visual.Arrange(new Rect(0, 0, visual.DesiredSize.Width, visual.DesiredSize.Height));
    
                visual.UpdateLayout();
    
                return visual;
            }
