    BindingOperations.ClearBinding(txtContent, TextBlock.TextProperty);
    Binding binding = new Binding("Content");
    binding.Source = source;
    binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
    binding.Mode = BindingMode.OneWay;
    txtContent.SetBinding(TextBox.TextProperty, binding);
