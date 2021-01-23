      public static class HttpPostedFileExtension
      {
        //Extend ForEach to IEnumerated Files
        public static void ProcessPostedFiles(this HttpFileCollection source, Func<HttpPostedFile, bool> predicate, Action<HttpPostedFile> action)
        {
          foreach (var item in source.AllKeys)
          {
            var httpPostedFile = source[item];
            if (predicate(httpPostedFile))
              action(httpPostedFile);
          }
        }  
      }
