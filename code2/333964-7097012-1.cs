     private class UpdateFilter : ActionFilterAttribute
        {
            private HtmlTextWriter tw;
            private StringWriter sw;
            private StringBuilder sb;
            private HttpWriter output;
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                sb = new StringBuilder();
                sw = new StringWriter(sb);
                tw = new HtmlTextWriter(sw);
                output = (HttpWriter)filterContext.RequestContext.HttpContext.Response.Output;
                filterContext.RequestContext.HttpContext.Response.Output = tw;
            }
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                string response = sb.ToString();
                //response processing
                output.Write(response);
            }
        }
