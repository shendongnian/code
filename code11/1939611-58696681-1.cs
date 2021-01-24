    public void Configure(IApplicationBuilder app) {
        app.Use(async (context, next) => {
            var request = context.Request;
            var method = request.Method;
            if (method == "GET" && !string.IsNullOrEmpty(request.ContentType) {
                request.ContentType = null;
            }
            // Call the next delegate/middleware in the pipeline
            await next(context);
        });
        
        //...
    }
