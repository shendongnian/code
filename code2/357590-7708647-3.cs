    public Color FilterColor
    {
    	get { return (Color)GetValue(FilterColorProperty); }
    	set { SetValue(FilterColorProperty, value); }
    }
    public static readonly DependencyProperty FilterColorProperty =
    	DependencyProperty.Register("FilterColor", typeof(Color), typeof(MainWindow), new UIPropertyMetadata(Colors.Transparent, new PropertyChangedCallback(_OnFilterColorPropertyChanged)));
    
    static void _OnFilterColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	var mw = d as MainWindow;
    
    	Color oldValue = (Color)e.OldValue;
    	Color newValue = (Color)e.NewValue;
    
    	if (null != mw && oldValue != newValue)
    	{
    		mw._OnFilterColorChanged(oldValue, newValue);
    	}
    }
    
    void _OnFilterColorChanged(Color oldValue, Color newValue)
    {
    	Brush = ...
    }
    
    public Brush FilterBrush
    {
    	get { return (Brush)GetValue(FilterBrushProperty); }
    	set { SetValue(FilterBrushProperty, value); }
    }
    public static readonly DependencyProperty FilterBrushProperty =
    	DependencyProperty.Register("FilterBrush", typeof(Brush), typeof(MainWindow), new UIPropertyMetadata(Brushs.Transparent, new PropertyChangedCallback(_OnFilterBrushPropertyChanged)));
    
    static void _OnFilterBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	var mw = d as MainWindow;
    
    	Brush oldValue = (Brush)e.OldValue;
    	Brush newValue = (Brush)e.NewValue;
    
    	if (null != mw && oldValue != newValue)
    	{
    		mw._OnFilterBrushChanged(oldValue, newValue);
    	}
    }
    
    void _OnFilterBrushChanged(Brush oldValue, Brush newValue)
    {
    	Color = ...
    }
