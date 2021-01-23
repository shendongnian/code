        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(YourType))
            {
                var instanceOfYourType = ...; 
                // load YourType from DB etc..
                var newBindingContext = new ModelBindingContext
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instanceOfYourType, typeof(YourType)),
                    ModelState = bindingContext.ModelState,
                    FallbackToEmptyPrefix = bindingContext.FallbackToEmptyPrefix,
                    ModelName = bindingContext.FallbackToEmptyPrefix ? string.Empty : bindingContext.ModelName,
                    ValueProvider = bindingContext.ValueProvider,
                };
                if (base.OnModelUpdating(controllerContext, newBindingContext)) // start loading..
                {
                    // bind all properties:
                    base.BindProperty(controllerContext, bindingContext, TypeDescriptor.GetProperties(typeof(YourType)).Find("Property1", false));
                    base.BindProperty(controllerContext, bindingContext, TypeDescriptor.GetProperties(typeof(YourType)).Find("Property2", false));
                    
                    // trigger the validators:
                    base.OnModelUpdated(controllerContext, newBindingContext);
                }
                return instanceOfYourType;
            }            
            throw new InvalidOperationException("Supports only YourType objects");
        } 
