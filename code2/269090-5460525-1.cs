    public class AbstractBindAttribute : CustomModelBinderAttribute
    {
        public string ConcreteTypeParameter { get; set; }
        public override IModelBinder GetBinder()
        {
            return new AbstractModelBinder(ConcreteTypeParameter);
        }
        private class AbstractModelBinder : DefaultModelBinder
        {
            private readonly string concreteTypeParameterName;
            public AbstractModelBinder(string concreteTypeParameterName)
            {
                this.concreteTypeParameterName = concreteTypeParameterName;
            }
            protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
            {
                var concreteTypeValue = bindingContext.ValueProvider.GetValue(concreteTypeParameterName);
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
        }
    }
