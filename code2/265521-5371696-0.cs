    TextBlock toolTipText = new TextBlock();
    
    MultiBinding multiBinding = new MultiBinding();
    multiBinding.StringFormat = "ValueOfProp1: {0}\nValueOfProp2: {1}\nValueOfProp3: {2}\n";
    
    multiBinding.Bindings.Add(new Binding
    {
        Source = this,
        Path = new PropertyPath("Property1")
    });
    multiBinding.Bindings.Add(new Binding
    {
        Source = this,
        Path = new PropertyPath("Property2")
    });
    multiBinding.Bindings.Add(new Binding
    {
        Source = this,
        Path = new PropertyPath("Property3")
    });
    
    toolTipText.SetBinding(TextBlock.TextProperty, multiBinding);
    
    ToolTip = toolTipText;
