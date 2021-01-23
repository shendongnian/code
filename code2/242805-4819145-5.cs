    namespace Log4NetTest
    {
      class HttpContextUserPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          string name = "";
          HttpContext context = HttpContext.Current;
          if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
          {
            name = context.User.Identity.Name;
          }
          writer.Write(name);
        }
      }
    }
