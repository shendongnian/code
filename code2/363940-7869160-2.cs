    public class YourModelBinderProvider : IModelBinderProvider
    {    
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType.IsInterface)
            {
                return new InterfaceModelBinder();
            }
            return null;
        }
    }
    public class InterfaceModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelBindingContext context = new ModelBindingContext(bindingContext);
            var concreteType = DependencyResolver.Current.GetService(bindingContext.ModelType);
            var item = Activator.CreateInstance(concreteType.GetType());          
            Func<object> modelAccessor = () => item;
            context.ModelMetadata = new ModelMetadata(new DataAnnotationsModelMetadataProvider(),
                bindingContext.ModelMetadata.ContainerType, modelAccessor, item.GetType(), bindingContext.ModelName);
            return base.BindModel(controllerContext, context);
        }
    }
