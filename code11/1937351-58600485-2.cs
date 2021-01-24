    [ProducesResponseType(400)]
    public class ValidateQueryStringStateAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
    
            var query = context.Request.Query;
    
            if(!query.ContainsKey("year") && !query.ContainsKey("genre"))
                context.ModelState.AddModelError("", "At least year or genre required");
    
            if (!context.ModelState.IsValid) {
                var result = new Dictionary<string, string>();
                foreach (var key in context.ModelState.Keys) {
                    result.Add(key, String.Join(", ", context.ModelState[key].Errors.Select(p => p.ErrorMessage)));
                }
    
                // 400 - Bad Request
                context.Result = new ObjectResult(result) { StatusCode = 400 };
            }
        }
    }
