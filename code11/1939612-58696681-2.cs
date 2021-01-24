    public void Configure(IApplicationBuilder app) {
        app.Use(async (context, next) => {
            var request = context.Request;
            var method = request.Method;
            IHeaderDictionary headers = request.Headers;
            string key = "Content-Type";
            if (method == "GET" && request.Headers.ContainesKey(key)) {
                headers.Remove(key);
            }
            // Call the next delegate/middleware in the pipeline
            await next();
        });
        
        //...
    }
