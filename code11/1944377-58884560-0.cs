        public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering(); // this part is crucial
                await this.next(context);
            }
            catch (Exception e)
            {
                
                var stream = context.Request.Body;
                stream.Seek(0, SeekOrigin.Begin);
                using var reader = new StreamReader(stream);
                var bodyString =  await reader.ReadToEndAsync();
               
                // log the error
            }
        }
    }
