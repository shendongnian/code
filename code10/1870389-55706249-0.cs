    public class CurrencyModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Currency))
                return new BinderTypeModelBinder(typeof(CurrencyModelBinder));
            return null;
        }
    }
