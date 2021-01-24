    public class SwaggerOperationFilter : IOperationFilter
    {
        private readonly IEnumerable<string> objectIdIgnoreParameters = new[]
        {
            nameof(ObjectId.Timestamp),
            nameof(ObjectId.Machine),
            nameof(ObjectId.Pid),
            nameof(ObjectId.Increment),
            nameof(ObjectId.CreationTime)
        };
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters = operation.Parameters.Where(x =>
                x.In != "query" || objectIdIgnoreParameters.Contains(x.Name) == false
            ).ToList();
        }
    }
