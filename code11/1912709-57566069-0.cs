      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string stringBody = string.Empty;
            try
            {
                await next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (context.Request.Body.CanSeek)
                {
                    stringBody = await FormatRequest(context.Request).ConfigureAwait(false);
                }
                await HandleExceptionAsync(context, ex, stringBody).ConfigureAwait(false);
            }
            //await next(context).ConfigureAwait(false);
        }
  
