    public class DynamicUrlHelper
    {
      private readonly ISomeDependency dep;
      public DynamicUrlHelper(ISomeDependency dep)
      {
        this.dep = dep;
      }
      public Uri DoMagic(Uri uri)
      {
        return uri.DoMagic(this.dep);
      }
    }
    public interface ISomeDependency
    {
    }
    public static class UrlHelper
    {
      public static Uri DoMagic(this Uri uri, ISomeDependency dep)
      {
        // do it!
        return uri;
      }
    }
