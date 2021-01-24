    private void AddTextBox(object sender, RoutedEventArgs e)
    {
        var myNewTextbox = new TextBox();
    
        var binding = new Binding
        {
            Source = this,
            Path = new PropertyPath("MyProp"),
            Mode = BindingMode.TwoWay
        };
        // Bind to the textbox
        myNewTextbox.SetBinding(TextBox.TextProperty, binding);
        grid.Children.Add(myNewTextbox);
    }     
    // The property definition
    public string MyProp { get; set; } = "test";
