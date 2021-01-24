    public class InjectXStuff : IDocumentFilter
    {
        public void Apply(SwaggerDocument s, DocumentFilterContext c)
        {
            PathItem path = s.Paths.Where(x => x.Key.Contains("Values")).First().Value;
            path.Post.Parameters.FirstOrDefault().Extensions.Add("x-stuff", "123456");
        }
    }
