    Binding binding = new Binding("Content");
    binding.Source = source;
    binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
    binding.Mode = BindingMode.TwoWay;
    txtContent.SetBinding(TextBox.TextProperty, binding);
