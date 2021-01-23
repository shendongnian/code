    public static class ElmahSensitiveDataFilter
    {
      public static void Apply(ExceptionFilterEventArgs e, HttpContext ctx)
      {
        var sensitiveFormData = ctx.Request.Form.AllKeys
                .Where(key => key.Equals("password", StringComparison.OrdinalIgnoreCase)).ToList();
        if (sensitiveFormData.Count == 0)
        {
          return;
        }
        var error = new Error(e.Exception, ctx);
        sensitiveFormData.ForEach(k => error.Form.Set(k, "*****"));
        Elmah.ErrorLog.GetDefault(null).Log(error);
        e.Dismiss();
      }
    }
