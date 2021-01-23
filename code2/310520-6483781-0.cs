    namespace System.Web.WebPages
    {
      public class WebPageHttpHandler : IHttpHandler, IRequiresSessionState
      {
        private static List<string> _supportedExtensions = new List<string>();
    
        public static void RegisterExtension(string extension)
        {
          WebPageHttpHandler._supportedExtensions.Add(extension);
        }
    
      // [snip]
    }
