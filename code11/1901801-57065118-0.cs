    public static readonly BindableProperty MascaraProperty = BindableProperty.Create(
        			nameof(Mascara),
        			typeof(MaskBehavior),
        			typeof(string));
        
    public string Mascara
    {
    	get => (string) GetValue(MascaraProperty);
    	set => SetValue(MascaraProperty, value);
    }
