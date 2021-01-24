    public static class ApiUtilities
        {
            public static IHttpActionResult TryCatch(Action action, ApiController apiController)
            {
                try
                {
                    if (apiController.ModelState.IsValid)
                    {
                        action();
    
                        return new OkResult(apiController);
                    }
                    else
                    {
                        return new BadRequestResult(apiController);
                    }
                }
                catch (Exception error)
                {
                    return new NotFoundResult(apiController);
                }
            }
            public static IHttpActionResult TryCatch<T>(Func<T> operation, ApiController apiController)
            {
                try
                {
                    if (apiController.ModelState.IsValid)
                    {
                        var result = operation();
    
                        return new OkNegotiatedContentResult<T>(result, apiController);
                    }
                    else
                    {
                        return new BadRequestResult(apiController);
                    }
                }
                catch (Exception error)
                {
                    return new NotFoundResult(apiController);
                }
            }
        }
