    public class NotEmptyListOfViewModels:IModelBinder
    {
        public async  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            //Get command model payload (JSON) from the body  
            String valueFromBody;
            using (var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody =await streamReader.ReadToEndAsync();
            }
            var modelInstance = JsonConvert.DeserializeObject<List<EventViewModel>>(valueFromBody);
            if(modelInstance.Count==0)
            {
                bindingContext.ModelState.AddModelError("JsonData", "The json is null !");
            }
            bindingContext.Result = ModelBindingResult.Success(modelInstance);
        }
    }
