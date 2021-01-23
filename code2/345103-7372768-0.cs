      public static class f
      {
         public static bool IS_GUEST
         {
            get
            {
               return (HttpContext.Current.Session["uid"] == null);
            }
         }
         public static bool IS_ADMIN
         {
            get
            {
               (HttpContext.Current.Session["admin"] != null);
            }
         }
