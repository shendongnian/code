    public class MyObject : IOpenApiAny
    {
        // implement everything here that IOpenApiAny defines:
        public AnyType AnyType { get; }
        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
        {
            // implementation
        }
    }
