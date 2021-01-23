    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (IsDesignTime)
        {
            // add code to init resource manager for design time
        }
        if (ResourceManager == null) 
            throw new InvalidOperationException();
        return ResourceManager.GetString(Key);
    }
