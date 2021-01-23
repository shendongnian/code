    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
               // Do something
    
               var model = (IInterface)Activator.CreateInstance(bindingContext.ModelType);
    
               // Do something
    
               bindingContext.Model = model;
               bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
               return Task.FromResult(model);
    } 
