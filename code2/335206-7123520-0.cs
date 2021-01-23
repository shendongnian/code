      public class UrlLinks
      {
           public static string HomeLink { get; protected set; }
           public static UrlLinks()
           {
                HomeLink = Link<HomeController>(x => x.Index());
           }
           protected static string Link<TControllerType>(Expression<Func<TControllerType, object>> expression)
           {
                return "methodName";
           }
      }
