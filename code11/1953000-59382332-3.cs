    public class RawBodyModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //use binder if parameter is string
            //and FromRawBody specified
            if (context.Metadata.ModelType == typeof(string) && 
                context.BindingInfo.BindingSource == CustomBindingSources.RawBody)
            {
                return new RawBodyModelBinder();
            }
            return null;
        }
    }
