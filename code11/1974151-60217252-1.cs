    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
     base.OnActionExecuting(filterContext);
        if (filterContext.ActionParameters.ContainsKey("jsonArray"))
        {
            List<string> deserializedJson = JsonConvert.DeserializeObject<List<string>>((string)filterContext.ActionParameters["jsonArray"]);
            if (deserializedJson.Count == 0)
            {
                filterContext.Controller.TempData["Error"] = "You must select one or items for this type of request";
                filterContext.Result = new RedirectResult("Index");
            }
        }
    }
