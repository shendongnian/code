    public class RawBodyModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using (var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                string result = await streamReader.ReadToEndAsync();
                bindingContext.Result = ModelBindingResult.Success(result);
            }
        }
    }
