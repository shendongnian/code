    public override object ProvideValue(IServiceProvider serviceProvider)
    {
    	/* if in design-mode return null */
    	if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
    		return null;
    
    	Style resultStyle = new Style();
    	foreach (string currentResourceKey in resourceKeys)
    	{
    		object key = currentResourceKey;
    		if (currentResourceKey == ".")
    		{
    			IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
    			key = service.TargetObject.GetType();
    		}
    		Style currentStyle = new StaticResourceExtension(key).ProvideValue(serviceProvider) as Style;
    		if (currentStyle == null)
    			throw new InvalidOperationException("Could not find style with resource key " + currentResourceKey + ".");
    		resultStyle.Merge(currentStyle);
    	}
    	return resultStyle;
    }
