    public class NetworkModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
    
            Network model;
    
            string bodyAsText = await new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEndAsync();
            model = JsonConvert.DeserializeObject<Network>(bodyAsText);
            model.TenantId = bindingContext.HttpContext.Request.Headers["TenantId"];
            bindingContext.Result = ModelBindingResult.Success(model);
        }
    }
