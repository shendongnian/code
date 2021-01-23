    public class JsonClientSideObjectWriterFactory : IClientSideObjectWriterFactory
    {
        public IClientSideObjectWriter Create(string id, string type, TextWriter textWriter)
        {
            return new JsonClientSideObjectWriter(id, type, textWriter);
        }
    }
