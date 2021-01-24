    public LabelWithTextBox()
    {
        InitializeComponent();
        Loaded += LabelWithTextBox_Loaded;
    }
    private static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(LabelWithTextBox),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    private void LabelWithTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        var binding = GetBindingExpression(TextProperty)?.ParentBinding;
        if (binding != null)
        {
            TextBox.SetBinding(RadWatermarkTextBox.TextProperty, binding);
        }
    }
