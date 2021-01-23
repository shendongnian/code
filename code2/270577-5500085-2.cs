    public static class AjaxExtensions
    {
        public static IHtmlString DefaultLink(this AjaxHelper helper, string text,
            string action, string controller, string updateTargetId = "", 
            string onSuccess = "")
        {
            // Build your link here eventually using 
            // the arguments passed
            var options = new AjaxOptions
            {
                OnSuccess = onSuccess,
                UpdateTargetId = updateTargetId,
                OnFailure = "handleError",
                LoadingElementId = "loading"
                // etc...
            }
            // return a normal ActionLink passing your options
            return helper.ActionLink(text, action, controller, options);
        }
    }
