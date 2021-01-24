    public class ResponseToStringMidleware
    {
        RequestDelegate _next;
    
        public ResponseToStringMidleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
            Stream responseBody = context.Response.Body;
            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;
    
                await _next(context);
                    
                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                {
                    memoryStream.Position = 0;
                    string html = new StreamReader(memoryStream).ReadToEnd();
                    // save the HTML
    
                }
                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(responseBody);
            }
        }
    }
