    private static readonly DependencyProperty CurrentInaccuracyRadiusProperty =
        DependencyProperty.Register
        (
            "CurrentInaccuracyRadius",
            typeof(double),
            typeof(PedestrianVisual),
            new UIPropertyMetadata(0.0, (s, e) =>
            {
                (s as PedestrianVisual).UpdateInaccuracyCircle((double)e.NewValue);
            })
        );
