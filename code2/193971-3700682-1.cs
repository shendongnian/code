    public static string GetId ( DependencyObject target )
    {
        return ( ( target.GetValue( IdProperty ) ) as string );
    }
    public static void SetId ( DependencyObject target, string value )
    {
        target.SetValue( IdProperty, value );
    }
    public static readonly DependencyProperty IdProperty = DependencyProperty.RegisterAttached(
        "SamplePropertyName",
        typeof( string ),
        typeof( Translatable ),
        new PropertyMetadata( IdPropertyChanged ) );
