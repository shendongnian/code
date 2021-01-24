C#
 public class SearchModelBinder : IModelBinder
    {
        private NameValueCollection _queryString;
        private List<string> GetValues(string key)
        {
            return (_queryString.GetValues(key) ?? throw new InvalidOperationException()).ToList();
        }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            _queryString = controllerContext.HttpContext.Request.QueryString;
            
            return _queryString.AllKeys.Select(x => new Filter { Name = x, Values = GetValues(x) }).ToList();
        }
    }
And then in controller action (notice parameter attribute)
C#
  public ActionResult Search([ModelBinder(typeof(SearchModelBinder))] List<Filter> filter)
    {
            // do something with filter
            return Content(filter.LastOrDefault()?.Name);
    }
