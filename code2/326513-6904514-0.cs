    protected override object CreateModel(ControllerContext controllerContext,ModelBindingContext bindingContext,Type modelType)
    {
        bool hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
        string prefix = ((hasPrefix)&&(bindingContext.ModelName!="")) ? bindingContext.ModelName + "." : "";
        // get the parameter species
        ValueProviderResult result;
        result = bindingContext.ValueProvider.GetValue(prefix+"species");
        if (result.AttemptedValue.Equals("cat")) 
        {
            var model = Activator.CreateInstance(typeof(Cat));
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(Cat));
            return model;
        }
        else if (result.AttemptedValue.Equals("dog"))
        {
            var model = Activator.CreateInstance(typeof(Dog));
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(Dog));
            return model;
        }
        throw new Exception(string.Format("Unknown type \"{0}\"", result.AttemptedValue));
    }
