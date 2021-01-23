    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var modelType = bindingContext.ModelType;
        if (modelType.IsAbstract)
        {
            var modelTypeValue = controllerContext.Controller.ValueProvider.GetValue("ModelTypeName");
            if (modelTypeValue == null)
                throw new Exception("View does not contain ModelTypeName");
            var modelTypeName = modelTypeValue.AttemptedValue;
            var type = modelType.Assembly.GetTypes().SingleOrDefault(x => x.IsSubclassOf(modelType) && x.Name == modelTypeName);
            if (type != null)
            {
                var instance= bindingContext.Model ?? base.CreateModel(controllerContext, bindingContext, type);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, type);
            }
        }
        return base.BindModel(controllerContext, bindingContext);
    }
}
