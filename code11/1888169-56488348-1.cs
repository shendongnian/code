        public class HeaderComplexModelBinderProvider : IModelBinderProvider
        {
                public IModelBinder GetBinder(ModelBinderProviderContext context)
                {
                if (context == null)
                {
                        throw new ArgumentNullException(nameof(context));
                }
                if (context.Metadata.IsComplexType)
                {
                        var x = context.Metadata as Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata;
                        var headerAttribute = x.Attributes.Attributes.Where(a => a.GetType() == typeof(FromHeaderAttribute)).FirstOrDefault();
                        if (headerAttribute != null)
                        {
                        return new BinderTypeModelBinder(typeof(HeaderComplexModelBinder));
                        }
                        else
                        {
                        return null;
                        }
                }
                else
                {
                        return null;
                }
                }
        }
