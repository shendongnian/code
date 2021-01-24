    public class CustomizedEnableQueryAttribute : EnableQueryAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var url = actionContext.Request.RequestUri.OriginalString;
            // add $orderby=Number to url
            if (url.ToLower().IndexOf("$orderby") == -1)
            {
                var orderByClause = "$orderby=Number";
                var newUrl = url.IndexOf('?') == -1
                    ? $"{url}?{orderByClause}"
                    : $"{url}&{orderByClause}";
                actionContext.Request.RequestUri = new Uri(newUrl);
            }
            base.OnActionExecuting(actionContext);
        }
    }
