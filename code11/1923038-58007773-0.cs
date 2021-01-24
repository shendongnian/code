    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        var controlTemplate = ControlTemplate;
        if (ReadonlyContent != null && controlTemplate != null)
        {
            SetInheritedBindingContext(ReadonlyContent, BindingContext);
        }
        if (WritableContent != null && controlTemplate != null)
        {
            SetInheritedBindingContext(WritableContent, BindingContext);
        }
    }
