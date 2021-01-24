    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var loop = bindingContext.HttpContext.Request.Form["cover.loop"][0];
            var freeMode = bindingContext.HttpContext.Request.Form["cover.freemode"][0];
            Cover cover = new Cover() {Loop=Convert.ToBoolean(loop),FreeMode= Convert.ToBoolean(freeMode) };
            var result= JsonConvert.SerializeObject(cover);
       
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
