`
public class RouteValueRequestCultureProvider : IRequestCultureProvider
    {
        private readonly CultureInfo[] _cultures;
        public RouteValueRequestCultureProvider(CultureInfo[] cultures)
        {
            _cultures = cultures;
        }
        /// <summary>
        /// get {culture} route value from path string, 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>ProviderCultureResult depends on path {culture} route parameter, or default culture</returns>
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var defaultCulture = "en";
            var path = httpContext.Request.Path;
            if (string.IsNullOrWhiteSpace(path))
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }
            var routeValues = httpContext.Request.Path.Value.Split('/');
            if (routeValues.Count() <= 1)
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }
            if (!_cultures.Any(x => x.Name.ToLower() == routeValues[1].ToLower()))
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }
            return Task.FromResult(new ProviderCultureResult(routeValues[1]));
        }
    }
`
- Add `RouteValueRequestCultureProvider` to the top of cultures providers list:
`
services.Configure<RequestLocalizationOptions>(ops =>
            {
                ops.DefaultRequestCulture = new RequestCulture("en");
                ops.SupportedCultures = cultures.OrderBy(x=>x.EnglishName).ToList();
                ops.SupportedUICultures = cultures.OrderBy(x => x.EnglishName).ToList();
                // add RouteValueRequestCultureProvider to the beginning of the providers list. 
                ops.RequestCultureProviders.Insert(0, 
                    new RouteValueRequestCultureProvider(cultures));
            });
`
- Create a culture template for routing, so we get the url as:
> http://mywebaddress.com/en-ES/
`
public class CultureTemplateRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;
            for (var i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];
                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Order = -1,
                        Template = AttributeRouteModel.CombineTemplates(
                      "{culture?}",
                      selector.AttributeRouteModel.Template),
                    }
                });
            }
        }
    }
`
- configure services to use the culture route template:
`
services.AddMvc()
        .AddRazorPagesOptions(o => {
            o.Conventions.Add(new CultureTemplateRouteModelConvention());
        });
`
see full tutorial [here](http://ziyad.info/en/articles/10-Developing_Multicultural_Web_Application).
- for creating the language drop down, you can either create it manually as described [here](http://ziyad.info/en/articles/14-Creating_Language_Dropdown_Navigation) or you may use [this nugget package](http://www.ziyad.info/en/articles/32-Language_Nav_TagHelper_for_ASP_NET_Core) to create it automatically with less code :)
