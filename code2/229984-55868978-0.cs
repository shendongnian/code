    public class IInterfaceBinderProvider : IModelBinderProvider
    {
           public IModelBinder GetBinder(ModelBinderProviderContext context)
           {
               if (context.Metadata.ModelType.GetInterface(nameof(IInterface)) != null)
               {
                   return new BinderTypeModelBinder(typeof(IInterface));
               }
    
               return null;
           }
    }
