public class CompressedJsonBinderProvider : IModelBinderProvider
{
   public IModelBinder GetBinder(Type modelType)
   {
       if(!modelType.IsGenericType)
            return null;
       var genericType =  modelType.GetGenericTypeDefinition();
       if(genericType == typeof(CompressedJsonViewModel<>))
           return new CompressedJsonModelBinder();
       return null;        
   }
}
By the way, this shows you the mechanics, but I'd also cache te=he type check in to avoid having to do the type reflection on every single request.
