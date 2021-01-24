    public class HealthCheckStatusFilter : IDocumentFilter
    {
    
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var pathItem = new PathItem();
            pathItem.Get = new Operation()
            {
                Tags = new[] { "ApiHealth" },
                Produces = new[] { "application/json" }
            };
            var properties = new Dictionary<string, Schema>();
            properties.Add("status", new Schema(){ Type = "string" });
            properties.Add("errors", new Schema(){ Type = "array" });
            var exampleObject = new { status = "Healthy", errors = new List<string>()};
            pathItem.Get.Responses = new Dictionary<string, Response>();
            pathItem.Get.Responses.Add("200", new Response() {
                Description = "OK",
                Schema = new Schema() {
                    Properties = properties,
                    Example = exampleObject }});
            swaggerDoc.Paths.Add(HealthCheckEndpoint, pathItem);
        }
    }
