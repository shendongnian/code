    public string TextToTest
    {
        get { return (string)this.GetValue(TextToTestProperty); }
        set { this.SetValue(TextToTestProperty, value); } 
    }
    public static readonly DependencyProperty TextToTestProperty = 
        DependencyProperty.Register("TextToTest", typeof(string), 
        typeof(MyControl), new PropertyMetadata(""));
