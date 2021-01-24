    public class EmptyCollectionModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(IEnumerable<FilterType>))
            {
                var elementBinder = context.CreateBinder(context.MetadataProvider.GetMetadataForType(typeof(FilterType)));
                return new EmptyCollectionModelBinder(elementBinder);
            }
            return null;
        }
    }
