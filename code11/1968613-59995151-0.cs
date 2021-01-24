        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                if (httpContext.Response.HasStarted) throw;
    
                var statusCode = ConvertExceptionToHttpStatusCode(exception);
    
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = (int)statusCode;
                httpContext.Response.ContentType = "application/json";
    
                if (statusCode != HttpStatusCode.BadRequest)
                {
                    _logger.Error(exception, "API Error");
                }
    
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new Error(statusCode, httpContext.Request.CorrelationId(), exception.Message, statusCode.ToString())));
            }
        }
