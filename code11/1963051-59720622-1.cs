    public class FeaturePolicyHeaderMiddleware {
        private RequestDelegate _next;
        private KeyValuePair<string, StringValues> header;
    
        public FeaturePolicyHeaderMiddleware(RequestDelegate next, KeyValuePair<string, StringValues> header) {
            _next = next;
            this.header = header;
        }
    
        public async Task Invoke(HttpContext context) {
            if (!context.Response.Headers.ContainsKey(header.Key)) {
                context.Response.Headers.Add(header);
            }
    
            await _next.Invoke(context);
        }
    }
