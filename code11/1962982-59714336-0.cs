    public double Radius
    {
    	get { return (double)GetValue(RadiusProperty); }
    	set { SetValue(RadiusProperty, value); }
    }
    
    public static readonly DependencyProperty RadiusProperty =
    	DependencyProperty.Register("Radius", typeof(double), typeof(RootControl), new PropertyMetadata(50.0));
