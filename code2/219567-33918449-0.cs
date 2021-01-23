        private static Assembly GetMyEntryAssembly()
        {
          if ((System.Web.HttpContext.Current == null) || (System.Web.HttpContext.Current.Handler == null))
            return Assembly.GetEntryAssembly(); // Not a web application
          return System.Web.HttpContext.Current.Handler.GetType().BaseType.Assembly;
        }
