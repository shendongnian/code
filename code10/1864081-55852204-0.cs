    class AcceptedObjectResult : ObjectResult
    {
        private readonly string _location;
    
        public AcceptedObjectResult(string location, object value) : base(value)
        {
            _location = location;
        }
    
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 202;
            var uri = new UriBuilder(context.HttpContext.Request.Scheme, context.HttpContext.Request.Host.Host)
            {
                Path = $@"api/{_location}",
            };
            if (context.HttpContext.Request.Host.Port.HasValue)
            {
                uri.Port = context.HttpContext.Request.Host.Port.Value;
            }
    
            context.HttpContext.Response.Headers.Add(@"Location", uri.ToString());
    
            return base.ExecuteResultAsync(context);
        }
    }
