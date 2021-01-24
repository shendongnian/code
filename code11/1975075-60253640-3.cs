    private void AddTextBox(object sender, RoutedEventArgs e)
    {
        var myNewTextbox = new TextBox();
    
        var binding = new Binding
        {
            Path = new PropertyPath("myDataBindingProperty"),
            Mode = BindingMode.TwoWay
        };
        // Bind to the textbox
        myNewTextbox.SetBinding(TextBox.TextProperty, binding);
        grid.Children.Add(myNewTextbox);
    }     
