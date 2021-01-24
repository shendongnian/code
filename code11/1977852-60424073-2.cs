        private class AddExampleDocumentFilter : IDocumentFilter
        {
            private List<Guid> Guids
            {
                get
                {
                    return new List<Guid>
                    {
                        Guid.Empty, Guid.Empty
                    };
                }
            }
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry s, IApiExplorer a)
            {
                if (swaggerDoc.paths.ContainsKey("/api/Dictionary"))
                {
                    var del = swaggerDoc.paths["/api/Dictionary"].delete;
                    if (del != null)
                    {
                        del.parameters[0].schema.example = Guids;
                    }
                }
            }
        }
