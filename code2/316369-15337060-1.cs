    void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
    {
        var ctx = e.Context as HttpContext;
        if(ctx == null)
        {
          return;
        }
        ElmahSensitiveDataFilter.Apply(e, ctx);
    }
