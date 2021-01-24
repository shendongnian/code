    public class testDtoEntityBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                {
                    throw new ArgumentNullException(nameof(bindingContext));
                }
                bindingContext.HttpContext.Request.EnableBuffering();
                var body = bindingContext.HttpContext.Request.Body;
                body.Position = 0;
                string raw = new System.IO.StreamReader(body).ReadToEnd();
                
                //now read content from request content and fill your model 
                var result = new testDto
                {
                    A = "",
                    B = 1,
                };
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }
        }
