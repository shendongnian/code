     private static readonly SensitiveDataJsonConverter SensitiveDataConverter = new SensitiveDataJsonConverter();
    
     public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
     {
         
         string safePayload;
         if (context.ActionArguments.Count == 1)
         {
             var safeObject = context.ActionArguments[context.ActionArguments.Keys.ElementAt(0)];
              safePayload = JsonConvert.SerializeObject(safeObject, Formatting.None, SensitiveDataConverter);
         }
         else
             safePayload = request.StoreAndGetPayload();
   
     // the rest..
    }
