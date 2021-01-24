    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    
    namespace **MyNamespaceHere**
    {
        /// <summary>
        /// Replace &amp; with ampersand character in XML comments
        /// </summary>
        internal class XmlCommentsEscapeFilter : IOperationFilter
        {
            public void Apply(Operation operation, OperationFilterContext context)
            {
                operation.Description = operation.Description?.Replace("&amp;", "&");
                operation.Summary = operation.Summary?.Replace("&amp;", "&");
            }
        }
    }
