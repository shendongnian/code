    public class DTModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            try
            {
                var result = new DataTableAjaxPostModel();
                if (bindingContext.HttpContext.Request.Query.Keys.Contains("draw"))
                    result.draw = int.Parse(bindingContext.ValueProvider.GetValue("draw").FirstValue);
                if (bindingContext.HttpContext.Request.Query.Keys.Contains("search[value]") &&
                    bindingContext.HttpContext.Request.Query.Keys.Contains("search[regex]"))
                    result.search = new search()
                    {
                        regex = bindingContext.ValueProvider.GetValue("search[regex]").FirstValue,
                        value = bindingContext.ValueProvider.GetValue("search[value]").FirstValue
                    };
                //...
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            return Task.CompletedTask;
        }
    }
