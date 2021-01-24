    public class TestModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var values = bindingContext.ValueProvider.GetValue("SampleProperty");
            string result = "";
            if (values.FirstValue == "abc")
            {
                result = "abc123";
            }else
            {
                result = values.FirstValue;
            }
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
