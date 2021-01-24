     public class DictionaryModelBinder:IModelBinder
    {
        public  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var result = new Dictionary<string, object> {};
            var form = bindingContext.HttpContext.Request.Form;
            if (form==null)
            {
                bindingContext.ModelState.AddModelError("FormData", "The data is null");
                return Task.CompletedTask;
            }
            foreach ( var k in form.Keys){
                StringValues v = string.Empty;
                var flag = form.TryGetValue(k, out v);
                if (flag)
                { 
                    result.Add(k, v );
                }
            }
        
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
