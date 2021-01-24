    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var binding = GetBindingExpression(TextProperty)?.ParentBinding;
        if (binding != null)
        {
            TextBox.SetBinding(RadWatermarkTextBox.TextProperty, binding);
        }
    }
