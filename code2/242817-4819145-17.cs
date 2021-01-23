    namespace Log4NetTest
    {
      class HttpContextSessionPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          //Use the value in Option as a key into HttpContext.Current.Session
          string setting = "";
          HttpContext context = HttpContext.Current;
          if (context != null)
          {
            object sessionItem;
            sessionItem = context.Session[Option];
            if (sessionItem != null)
            {
              setting = sessionItem.ToString();
            }
            writer.Write(setting);
          }
        }
      }
    }
    namespace Log4NetTest
    {
      class HttpContextItemPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          //Use the value in Option as a key into HttpContext.Current.Session
          string setting = "";
          HttpContext context = HttpContext.Current;
          if (context != null)
          {
            object item;
            item = context.Items[Option];
            if (item != null)
            {
              setting = item.ToString();
            }
            writer.Write(setting);
          }
        }
      }
    }
