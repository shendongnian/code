    public class CustomModelBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var values = bindingContext.ValueProvider.GetValue("city");
            if (values.Length == 0)
                return Task.CompletedTask;
            var result = new RNote
            {
                city = values.ToString()
            };
              bindingContext.Result = ModelBindingResult.Success(result);
         
            return Task.CompletedTask;
        }
    }
