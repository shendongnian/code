    public static readonly DependencyProperty SpinnerSourceProperty =
        DependencyProperty.Register(
            nameof(SpinnerSource), typeof(ImageSource), typeof(Spinner));
    public ImageSource SpinnerSource
    {
        get { return (ImageSource)GetValue(SpinnerSourceProperty); }
        set { SetValue(SpinnerSourceProperty, value); }
    }
