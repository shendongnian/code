    public class WebApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // My web API client will throw a WebApiException if it doesn't produce a successful response
            if (context.Exception is WebApiException webApiEx)
            {
                switch (webApiEx.StatusCode)
                {
                    case StatusCodes.Status400BadRequest:
                        ViewDataDictionary viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                            context.ModelState);
                        context.ModelState.AddJsonModelErrors(webApiEx.Response); // This method de-serialises the model state from the web API response
                                                                                  // and adds it to the MVC model state
                        viewData.Model = new Product(); //replace it with your model from WebApiException
                        context.Result = new ViewResult() {
                            ViewName = "Create", //replace it with your real view from WebApiException
                            ViewData = viewData,
                        };
                        
                        context.ExceptionHandled = true;
                        return;
                }
            }
        }
    }
