    protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties, IValueProvider valueProvider) where TModel: class
    {
        if (model == null)
        {
            throw new ArgumentNullException("model");
        }
        if (valueProvider == null)
        {
            throw new ArgumentNullException("valueProvider");
        }
        Predicate<string> predicate = delegate (string propertyName) {
            return BindAttribute.IsPropertyAllowed(propertyName, base.includeProperties, base.excludeProperties);
        };
        IModelBinder binder = this.Binders.GetBinder(typeof(TModel));
        ModelBindingContext context2 = new ModelBindingContext();
        context2.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(delegate {
            return base.model;
        }, typeof(TModel));
        context2.ModelName = prefix;
        context2.ModelState = this.ModelState;
        context2.PropertyFilter = predicate;
        context2.ValueProvider = valueProvider;
        ModelBindingContext bindingContext = context2;
        binder.BindModel(base.ControllerContext, bindingContext);
        return this.ModelState.IsValid;
    }
