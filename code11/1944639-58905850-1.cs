    public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "DELETE");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "content-type");
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                return;
            }
            .
            .
            .
        }
