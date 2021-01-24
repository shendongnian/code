    public async Task Invoke(HttpContext context)
    {
      try
      {
        await this.next(context);
      }
      catch (Exception e)
      {
        var username = context.User?.Identity?.Name ?? "__unknown";
        using (LogContext.PushProperty("Username", username))
        {
         this.logger.Log(......)
        }
      }
    }
