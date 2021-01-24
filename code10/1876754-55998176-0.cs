    internal class QueryStringDictSyntaxBinder<TModel> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            try
            {
                var result = Activator.CreateInstance<TModel>();
                foreach(var pi in typeof(TModel).GetProperties())
                {
                    var modelName = bindingContext.ModelName;
                    var qsFieldName = $"{modelName}[{pi.Name}]";
                    var field= bindingContext.HttpContext.Request.Query[qsFieldName].FirstOrDefault();
                    if(field != null){
                        pi.SetValue(result,field);
                    }
                    // do nothing if null , or add model binding failure messages if you like
                }
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            return Task.CompletedTask;
        }
    }
