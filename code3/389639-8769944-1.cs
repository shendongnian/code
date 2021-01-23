    private ImageSourceWrapper _imageSourceWrapper;
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        // Get the object and the property to be bound.
        IProvideValueTarget service = IProvideValueTarget)provider.GetService(typeof(IProvideValueTarget));
        DependencyObject targetObject = service.TargetObject as DependencyObject;
        DependencyProperty targetProperty = service.TargetProperty as DependencyProperty;
        // Set up the binding with the default image.
        _imageSourceWrapper = new ImageSourceWrapper(DefaultImage);
        Binding binding = new Binding("Image");
        binding.Source = _imageSourceWrapper;
        BindingOperations.SetBinding(targetObject, targetProperty, binding);
        // Retrieve the actual image asynchronously.
        GetImageAsync();
        return binding.ProvideValue(serviceProvider);
    }
    private void GetImageAsync()
    {
        // Get the image asynchronously.
        // Freeze the image so it could be accessed from all threads regardless
        // of which thread it was created on.
        newImage.Freeze();
        // Got the image - update the _imageSourceWrapper object.
        _imageSourceWrapper = newImage;
    }
