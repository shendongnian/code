    public class SwaggerDocumentProcessor : IDocumentProcessor
    {
        public Task ProcessAsync(DocumentProcessorContext context)
        {
            context.Document.Info.Title = "My API Title";
            context.Document.Info.Version = "v1.4";
            foreach (var path in context.Document.Paths)
            {
                foreach (var item in path.Value.Values)
                {
                    item.Description = item.Description.Replace("&amp;", "&");
                }
            }
            context.Document.Info.Description = "Description with markdown";
            context.Document.Info.ExtensionData = new ConcurrentDictionary<string, object>();
            context.Document.Info.ExtensionData.Add("x-logo", new
            {
                url =
                    "https://www.logos.com/mylogo.jpg",
                    altText = "Logo",
                href = "https://website.com/"
            });
            return Task.CompletedTask;
        }
    }
