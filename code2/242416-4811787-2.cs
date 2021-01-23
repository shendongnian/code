    public static class MyAppSession {
      const string IsLoggedInKey = "IsLoggedIn";
      public static bool IsLoggedIn {
        get { 
          return Session[IsLoggedInKey] != null && (bool)Session[IsLoggedInKey]; 
        }
        internal set { Session[IsLoggedInKey] = value; }
      }
      // ...
      private static HttpSessionState Session {
        get { return HttpContext.Current.Session; }
      }
    }
