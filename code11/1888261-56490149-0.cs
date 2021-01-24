    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.CreateAttached(
    "BackgroundColor",
    typeof(Color),
    typeof(ColorProperties),
    Color.Red,
    propertyChanged: ((bindable, value, newValue) =>
    {
        System.Diagnostics.Debug.WriteLine(value);
    
        var control = bindable as View;
        if (control != null)
        {
            control.BackgroundColor = (Color)newValue;
        }
    }));
