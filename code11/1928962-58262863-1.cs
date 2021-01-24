    ```csharp
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
        var request = bindingContext.ActionContext.HttpContext.Request;
    
        var model = new SignInRequestModel();
        var pis = typeof(SignInRequestModel).GetProperties();
        foreach(var pi in pis){
            var pv = bindingContext.ValueProvider.GetValue(pi.Name); // prop value
            pi.SetValue(model,pv.FirstValue);                  
        }
        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }
    ```
    This also works. But the first way is preferred because that's a robust way.
