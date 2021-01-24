    public static readonly DependencyProperty SliderValueProperty = DependencyProperty.Register("SliderValue", typeof(double), typeof(MyUserControl), new PropertyMetadata((double)0));
    public double SliderValue
    {
        get
        {
            return (double)GetValue(SliderValueProperty );
        }
        set
        {
            SetValue(SliderValueProperty , value);
        }
    }
