    internal static readonly DependencyPropertyKey CustomPrKey = DependencyProperty.RegisterReadOnly(
     "CustomPr",
     typeof(string),
     typeof(CustomView),
     new PropertyMetadata(string.Empty)
    );
    public static readonly DependencyProperty CustomPrProperty = CustomPrKey.DependencyProperty;
    public string CustomPr
    {
        get { return (string)GetValue(CustomPrProperty); }
    }
