    public class MyCustomerModelBinder:IModelBinder
    {
        public  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            
            var modelResult = new ObjectModel();
            //Get the Query in the request 
            var queryResult =new Dictionary<string, string>();
            var query = bindingContext.HttpContext.Request.Query;
            foreach (var k in query.Keys)
            {
                StringValues v = string.Empty;
                var flag = query.TryGetValue(k, out v);
                if (flag)
                {
                    queryResult.Add(k, v);
                }
            }
            
            // Bind model when UserId exists in the Query
            if (queryResult.ContainsKey("UserId"))
            {
                modelResult.Id =Convert.ToInt32(bindingContext.ValueProvider.GetValue("id").FirstValue);
                modelResult.UserId =Convert.ToInt32(bindingContext.ValueProvider.GetValue("UserId").FirstValue);
                bindingContext.Result = ModelBindingResult.Success(modelResult);
                return Task.CompletedTask;
            }
            modelResult = null;
            bindingContext.Result = ModelBindingResult.Success(modelResult);
            return Task.CompletedTask;
        }
    }
    
