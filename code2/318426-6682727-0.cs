    // Add binding
    var b = new Binding("Text", myDataSource, "BoundProperty");
    b.Parse += OnNullableTextBindingParsed;
    myTextBox.DataBindings.Add(b);
    // Sample parse handler
    private void OnNullableTextBindingParsed(object sender, ConverterEventArgs e)
    {
        if (e.Value == String.Empty) e.Value = null;
    }
