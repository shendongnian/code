        private List<string> getJson(string jsonArray)
        {
            List<string> deserializedJson = JsonConvert.DeserializeObject<List<string>>(jsonArray);
            return deserializedJson;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.ActionParameters.ContainsKey("jsonArray"))
            {
                List<string> deserializedJson = getJson((string)filterContext.ActionParameters["jsonArray"]);
                if (deserializedJson.Count == 0)
                {
                    filterContext.Controller.TempData["Error"] = "You must select one or items for this type of request";
                    filterContext.Result = new RedirectResult("Index");
                }
            }
        }
        public ActionResult doSomething(string jsonArray)
        {
           List<string> deserializedJson = getJson(jsonArray);
          //business as usual stuff here
         }
2. create a filter and apply it to each method:
    [CheckArray]
    public ActionResult doSomething(string jsonArray)
    {
        List<string> deserializedJson = getJson(jsonArray);
       //business as usual stuff here
    }
    public class CheckArrayAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          List<string> deserializedJson = getJson((string)filterContext.ActionParameters["jsonArray"]);
         if (deserializedJson.Count == 0)
          {
             filterContext.Controller.TempData["Error"] = "You must select one or items for this type of request";
             filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = filterContext.RequestContext.RouteData.Values["controller"], action = "Index" }));
           }
         }
    }
