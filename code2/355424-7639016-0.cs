    public class CheckMetadataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // get model?
            var result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                var model = result.Model;
                if (model != null)
                {
                    // get metadata for model (you have a single model, no idea what you meant by "for each model" in your question)
                    var metadata = ModelMetadataProviders.Current.GetMetadataForType(null, model.GetType());
                    if (metadata.DisplayName == "foo bar")
                    {
                        // set viewdata if metadata X exists
                        filterContext.Controller.ViewData["foo"] = "bar";
                    }
                }
            }
        }
    }    
