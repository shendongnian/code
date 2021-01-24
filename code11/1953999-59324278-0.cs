    public class DeviceTypeDataContractProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Product))
            {
                return new DeviceModelBinder();
            }
            return null;
        }
    }
    public class DeviceModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var reader = new JsonTextReader(new StreamReader(bindingContext.HttpContext.Request.Body));
            //loading request json
            var jObject = JObject.Load(reader);
            JToken data = jObject["data"];
            Product result = jObject.ToObject<Product>();
            switch (result.Data.Kind)
            {
                case "teddy":
                    result.Data = data.ToObject<Teddybear>();
                    break;
                case "lego":
                    result.Data = data.ToObject<Legobrick>();
                    break;
                default:
                    bindingContext.Result = ModelBindingResult.Failed();
                    return Task.CompletedTask;
            }
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
