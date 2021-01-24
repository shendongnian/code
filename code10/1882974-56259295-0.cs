    public void OnActionExecuting(ActionExecutingContext context)
       {              
        var request = context.HttpContext.Request;
         try
            {
                request.EnableRewind();
                using (StreamReader reader = new StreamReader(request.Body))
                {
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                request.Body = request; 
            }
            context.Request.Body.Position = 0
            return string.Empty;
        }
