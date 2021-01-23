    public class CustomModelBinder : DefaultModelBinder 
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.IsAbstract)
            {
                var modelTypeValue = controllerContext.Controller.ValueProvider.GetValue("ModelTypeName");
                if (modelTypeValue == null)
                    throw new Exception("View does not contain ModelTypeName");
                var modelTypeName = modelTypeValue.AttemptedValue;
                var type = modelType.Assembly.GetTypes().SingleOrDefault(x => x.IsSubclassOf(modelType) && x.Name == modelTypeName);
                if(type == null)
                    throw new Exception("Invalid ModelTypeName");
                var concreteInstance = Activator.CreateInstance(type);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => concreteInstance, type);
                return concreteInstance;
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
