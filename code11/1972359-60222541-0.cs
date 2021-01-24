    public class DynamicModelBinder:IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var result = new Dictionary<string, dynamic> { };
            var query = bindingContext.HttpContext.Request.Query;
            if (query == null)
            {
                bindingContext.ModelState.AddModelError("QueryString", "The data is null");
                return Task.CompletedTask;
            }
            
            foreach (var k in query.Keys)
            {
                StringValues v = string.Empty;
                var flag = query.TryGetValue(k, out v);
                if (flag)
                {
                    if (v.Count > 1)
                    {
                        result.Add(k, v);
                    }
                    else { 
                    result.Add(k, v[0]);
                    }
                }
            }
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
