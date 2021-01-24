    public class ImageRewriteRule : IRule
    {
        private readonly ImageRewriteCollection rewriteCollection;
        private readonly Regex pathRegex = new Regex("^/images/(\\d+).jpg");
        public ImageRewriteRule(ImageRewriteCollection rewriteCollection)
        {
            this.rewriteCollection = rewriteCollection;
        }
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var pathMatch = pathRegex.Match(request.Path.Value);
            if (pathMatch.Success)
            {
                bool isValidPath = true;
                int id = int.Parse(pathMatch.Groups[1].Value);
                int width = 0;
                int height = 0;
                string widthQuery = request.Query["width"];
                string heightQuery = request.Query["height"];
                if (widthQuery == null || !int.TryParse(widthQuery, out width))
                    isValidPath = false;
                if (heightQuery == null || !int.TryParse(heightQuery, out height))
                    isValidPath = false;
                if (isValidPath && rewriteCollection.TryGetValue(id, width, height, out string path))
                {
                    request.Path = path;
                    context.Result = RuleResult.SkipRemainingRules;
                }
            }
        }
    }
