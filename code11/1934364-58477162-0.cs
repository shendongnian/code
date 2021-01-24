    public static BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(GradientButton), defaultValue: Color.Default, defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (b, o, n) =>
            {
                var ctrl = (GradientButton)b;
                ctrl.StartColor = (Color)n;
            });
    public static BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(GradientButton), defaultValue: Color.Default, defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (b, o, n) =>
            {
                var ctrl = (GradientButton)b;
                ctrl.EndColor = (Color)n;
            });
