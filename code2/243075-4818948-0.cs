    public double BubbleOpacity {
       get { return (double)GetValue(BubbleOpacityProperty); }
       set { SetValue(BubbleOpacityProperty, value); }
    }
    
    public static readonly DependencyProperty BubbleOpacityProperty =
       DependencyProperty.Register("BubbleOpacity", typeof(double), typeof(Window), new UIPropertyMetadata(1d));
