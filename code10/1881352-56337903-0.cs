    public class HalMiddleware
    {
        private RequestDelegate next;
        public HalMiddleware(RequestDelegate next)
        {
            // We need the MVC pipeline after our custom middleware.
            this.next = next
                ?? throw new ArgumentNullException(nameof(next));
        }
        
        public async Task Invoke(HttpContext context)
        {
            // Invoke the 'normal' pipeline first.
            // Note that the mvc middleware would serialize the response...
            // Prevent that by injecting a custom IActionResultExecutor<ObjectResult>, 
            // that sets the ActionResult to the context instead of serializing.
            await this.next(context);
    
            // Our objectresultexecutor added some information on the HttpContext.
            if (!context.Items.TryGetValue("HalFormattingContext", out object formatObject)
                ||!(formatObject is HalFormattingContext halFormattingContext))
            {
                logger.LogDebug("Hal formatting context not found, other formatters are handling this response.");
                return;
            }
            // some code to create a resource object from the result.
            var rootResource = ConstructRootResource(halFormattingContext.ObjectResult);
            halFormattingContext.ObjectResult.Value = rootResource;
            // some code to figure out which actions/routes to embed.
            var toEmbeds = GetRoutesToEmbed(halFormattingContext.ActionContext);
            var requestFeature = context.Features.Get<IHttpRequestFeature>();
            foreach (var toEmbed in toEmbeds)
            {
                var halRequestFeature = new HalHttpRequestFeature(requestFeature)
                {
                    Method = "GET",
                    Path = toEmbed.Path
                };
                // The HalHttpContext creates a custom request and response in the constructor 
                // and creates a new feature collection with custom request and response features.
                var halContext = new HalHttpContext(context, halRequestFeature);
                await this.next(halContext);
                
                // Now the custom ObjectResultExecutor set the ActionResult to a property of the custom HttpResponse.
                var embedActionResult = ((HalHttpResponse)halContext.Response).ObjectResult;
    
                // some code to embed the new actionresult.
                Embed(rootResource, embedActionResult, toEmbed);
            }
            // Then invoke the default ObjectResultExecutor to serialize the new result.
            await halFormattingContext.DefaultExecutor.ExecuteAsync(
                halFormattingContext.ActionContext,
                halFormattingContext.ObjectResult);
        }
    }
