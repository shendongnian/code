    static readonly DependencyProperty CurrentInaccuracyRadiusProperty =
    DependencyProperty.Register
    (
        "CurrentInaccuracyRadius",
        typeof(double),
        typeof(PedestrianVisual),
        new UIPropertyMetadata(0.0, OnCurrentInaccuracyRadiusChanged)
    );
    static void OnCurrentInaccuracyRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var pedVisual = d as PedestrianVisual;
        if (pedVisual != null)
            pedVisual.OnCurrentInaccuracyRadiusChanged((double)e.OldValue, (double)e.NewValue);
    }
    void OnCurrentInaccuracyRadiusChanged(double oldValue, double newValue)
    {
        UpdateInaccuracyCircle(newValue);
    }
