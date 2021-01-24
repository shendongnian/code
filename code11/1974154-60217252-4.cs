    [CheckArray]
    public ActionResult doSomething(string jsonArray)
    {
        List<string> deserializedJson = JsonConvert.DeserializeObject<List<string>>(jsonArray);
       //business as usual stuff here
    }
    public class CheckArrayAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          List<string> deserializedJson = JsonConvert.DeserializeObject<List<string>>((string)filterContext.ActionParameters["jsonArray"]);
         if (deserializedJson.Count == 0)
          {
             filterContext.Controller.TempData["Error"] = "You must select one or items for this type of request";
             filterContext.Result = new RedirectResult("Index");
           }
         }
    }
