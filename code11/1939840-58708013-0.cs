public async Task Invoke(HttpContext httpContext, IApiLogService apiLogService)
 {
     try
     {
         _apiLogService = apiLogService;
         var request = httpContext.Request;
         if (request.Path.StartsWithSegments(new PathString("/api")))
         {
             var stopWatch = Stopwatch.StartNew();
             var requestTime = DateTime.UtcNow;
             var requestBodyContent = await ReadRequestBody(request);
             var originalBodyStream = httpContext.Response.Body;
             await SafeLog(requestTime,
                   stopWatch.ElapsedMilliseconds,
                   200,//response.StatusCode,
                   request.Method,
                   request.Path,
                   request.QueryString.ToString(),
                   requestBodyContent
                   );           
         };
     }
     catch (Exception ex)
     {
         
     }
     await _next(httpContext);
 }
