    public class InstantModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context) =>
            context.Metadata.ModelType == typeof(Instant) ? new InstantModelBinder(context.Metadata.ParameterName) : null;
    }
    public class InstantModelBinder : IModelBinder
    {
        private readonly string parameterName;
        public InstantModelBinder(string parameterName)
        {
            this.parameterName = parameterName;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var text = bindingContext.ActionContext.HttpContext.Request.Query[parameterName];
            if (text.Count != 1)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            else
            {
                var result = InstantPattern.ExtendedIso.Parse(text);
                bindingContext.Result = result.Success
                    ? ModelBindingResult.Success(result.Value)
                    : ModelBindingResult.Failed();
            }
            return Task.CompletedTask;
        }
    }
