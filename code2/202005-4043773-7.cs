        public static void AddModelStateErrors(this System.Web.Mvc.ModelStateDictionary modelState, RulesException exception)
        {
            foreach (ErrorInfo info in exception.Errors)
            {
                modelState.AddModelError(info.PropertyName, info.ErrorMessage);
            }
        }
