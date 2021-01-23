        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties, IDictionary<string, ValueProviderResult> valueProvider) where TModel : class {
            if (model == null) {
                throw new ArgumentNullException("model");
            }
            if (valueProvider == null) {
                throw new ArgumentNullException("valueProvider");
            }
            Predicate<string> propertyFilter = propertyName => BindAttribute.IsPropertyAllowed(propertyName, includeProperties, excludeProperties);
        IModelBinder binder = Binders.GetBinder(typeof(TModel));
        ModelBindingContext bindingContext = new ModelBindingContext() {
            Model = model,
            ModelName = prefix,
            ModelState = ModelState,
            ModelType = typeof(TModel),
            PropertyFilter = propertyFilter,
            ValueProvider = valueProvider
        };
        binder.BindModel(ControllerContext, bindingContext);
        return ModelState.IsValid;
    }
