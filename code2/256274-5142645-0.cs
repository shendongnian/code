    var aBinding = new Binding();
    aBinding.ElementName = "slider1"; // name of the slider
    aBinding.Path = new PropertyPath("Value");
    BindingOperations.SetBinding(
        btnScaleTransform, // the ScaleTransform to bind to
        ScaleTransform.ScaleXProperty,
        aBinding);            
