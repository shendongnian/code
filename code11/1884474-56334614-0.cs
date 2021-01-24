        [HtmlTargetElement("a-link")]
        public class MyAnchorTagHelper : AnchorTagHelper
        {
            private readonly HttpContext _httpContext;
            public MyAnchorTagHelper(IHtmlGenerator generator
                , IHttpContextAccessor httpContextAccessor) : base(generator)
            {
                _httpContext = httpContextAccessor.HttpContext;
            }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                base.Process(context, output);
                output.TagName = "a";
                var basePath = $"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}{_httpContext.Request.PathBase}";
                TagHelperAttribute href;
                if (output.Attributes.TryGetAttribute("href", out href))
                {
                    output.Attributes.SetAttribute("href", $"{basePath}{href.Value}");
                }
            }
        }
