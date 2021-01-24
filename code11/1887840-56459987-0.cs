    private DoubleAnimation widthAnimation;
    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property == WidthProperty &&
            !double.IsNaN((double)e.OldValue) &&
            widthAnimation == null)
        {
            widthAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = (double)e.OldValue,
                To = (double)e.NewValue
            };
            widthAnimation.Completed += (s, a) =>
            {
                widthAnimation = null;
                BeginAnimation(WidthProperty, null);
            };
            BeginAnimation(WidthProperty, widthAnimation);
        }
        else
        {
            base.OnPropertyChanged(e);
        }
    }
