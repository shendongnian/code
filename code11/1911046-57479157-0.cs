    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    /// <summary>
    /// A DocumentFilter that lowers the first letter of the query parameters.
    /// </summary>
    public class NameDocumentFilter : IDocumentFilter
    {
        #region explicit interfaces
        /// <inheritdoc />
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Paths.Count <= 0)
            {
                return;
            }
            foreach (var path in swaggerDoc.Paths.Values)
            {
                ToLower(path.Parameters);
                // Edit this list if you want other operations.
                var operations = new List<Operation>
                {
                    path.Get,
                    path.Post,
                    path.Put
                };
                operations.FindAll(x => x != null)
                    .ForEach(x => ToLower(x.Parameters));
            }
        }
        #endregion
        #region methods
        /// <summary>
        /// Lowers the first letter of a parameter name.
        /// </summary>
        private static void ToLower(IList<IParameter> parameters)
        {
            if (parameters == null)
            {
                return;
            }
            foreach (var param in parameters)
            {
                // limit the renaming only to query parameters
                if (!param.In.Equals("query", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                // shouldn't happen, just to make sure
                if (string.IsNullOrWhiteSpace(param.Name))
                {
                    continue;
                }
                param.Name = param.Name[0]
                                 .ToString()
                                 .ToLower() + param.Name.Substring(1);
            }
        }
        #endregion
    }
