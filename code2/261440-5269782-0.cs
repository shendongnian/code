      public static class HttpPostedFileExtension
      {
        //Extend ForEach to IEnumerated Files
        public static IEnumerable<HttpPostedFile> PostedFiles(this HttpFileCollection source)
        {
          foreach (var item in source.AllKeys)
            yield return source[item];
        }  
      }
