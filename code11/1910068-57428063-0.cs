    public event EventHandler ValueChanged;
    public double Value
    {
        get { return (double)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(SpeedoMeter), new PropertyMetadata(0.0,
            OnChanged,
            OnCoerceValueChanged));
    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        SpeedoMeter speedoMeter = (SpeedoMeter)d;
        EventHandler handler = speedoMeter.ValueChanged;
        if (handler != null)
        {
            handler(speedoMeter, EventArgs.Empty);
        }
    }
