    public class ValidateAttribute : ActionFilterAttribute
    {
        public string Exclude { get; set; }
        public string Base { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!string.IsNullOrWhiteSpace(this.Exclude))
            {
                string[] excludes = this.Exclude.Split(',');
                foreach (var exclude in excludes)
                {
                    actionContext.ModelState.Remove(Base + "." + exclude);
                }
            }
            if (actionContext.ModelState.IsValid == false)
            {
                var mediaType = new MediaTypeHeaderValue("application/json");
                var error = actionContext.ModelState;
               
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, error.Keys, mediaType);
             
            }
        }
    }
