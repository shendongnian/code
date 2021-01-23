    public class AbstractModelBinder : DefaultModelBinder
    {
        private const string concreteTypeFormat = "{0}ConcreteType";
        private const string modelNameMetadataAdditionalValue = "ModelName";
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.IsAbstract)
            {
                var propertyName = (string)bindingContext.ModelMetadata.AdditionalValues[modelNameMetadataAdditionalValue];
                var concreteTypeValue = bindingContext.ValueProvider.GetValue(string.Format(concreteTypeFormat, propertyName));
                
                if (concreteTypeValue == null)
                    throw new Exception("Concrete type value not specified for abstract class binding");
                var concreteType = Assembly.GetExecutingAssembly().GetType(concreteTypeValue.AttemptedValue);
                if (concreteType == null)
                    throw new Exception("Cannot create abstract model");
                if (!concreteType.IsSubclassOf(modelType))
                    throw new Exception("Incorrect model type specified");
                var concreteInstance = Activator.CreateInstance(concreteType);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => concreteInstance, concreteType);
                return concreteInstance;
            }
            else
                return base.CreateModel(controllerContext, bindingContext, modelType);
        }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            bindingContext.ModelMetadata.AdditionalValues[modelNameMetadataAdditionalValue] = bindingContext.ModelName;
            return base.BindModel(controllerContext, bindingContext);
        }
    }
