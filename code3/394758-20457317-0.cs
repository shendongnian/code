     public override void OnException(HttpActionExecutedContext filterContext)
            {
        var message = new StringBuilder();
                foreach (var param in filterContext.ActionContext.ActionArguments)
                {
                    message.Append(string.Format("{0}:{1}\r\n", param.Key, Newtonsoft.Json.JsonConvert.SerializeObject(param.Value)));
                }
                var ex = new Exception(message.ToString(), filterContext.Exception);
                var context = HttpContext.Current;
                ErrorLog.GetDefault(context).Log(new Error(ex, context));
    }
