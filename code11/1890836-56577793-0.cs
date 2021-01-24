    [HtmlTargetElement("a", Attributes = RouteValuesDictionaryName)]
    [HtmlTargetElement("a", Attributes = RouteValuesPrefix + "*")]
    public class SearchLinkTagHelper : TagHelper
    {
        private const string RouteValuesDictionaryName = "my-all-route-data";
        private const string RouteValuesPrefix = "my-route-";
        private const string Href = "href";
        private IDictionary<string, string> _routeValues;
        public override int Order => 1;
        [HtmlAttributeName(RouteValuesDictionaryName, DictionaryAttributePrefix = RouteValuesPrefix)]
        public IDictionary<string, string> RouteValues
        {
            get => _routeValues ?? (_routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            set => _routeValues = value;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.TryGetAttribute(Href, out var href);
            var fixedRouteValues = new Dictionary<string, string>();
            foreach (var (newKey, value) in _routeValues.Where(r=>!string.IsNullOrWhiteSpace(r.Value)))
            {
                var key = fixedRouteValues.Keys.FirstOrDefault(k => string.Equals(k, newKey, StringComparison.InvariantCultureIgnoreCase)) ?? newKey;
                fixedRouteValues[key] = value;
            }
            var query = string.Join("&", fixedRouteValues.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            var hrefValue = href.Value;
            output.Attributes.Remove(href);
            href = new TagHelperAttribute(Href, hrefValue + "?" +query);
            output.Attributes.Add(href);
        }
    }
