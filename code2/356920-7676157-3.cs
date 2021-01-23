      public delegate int IdGetter<in T>(T holder);
      public delegate T IdSetter<T>(T holder, int newId);
      private static void RewriteIListIds<T>(IList<T> pre, IList<T> post, 
                                             IdGetter<T> getId, IdSetter<T> setId)
      {
         if (post != null && post.Count > 0)
         {
            for (int i = 0; i < post.Count; i++)
            {
               T preElement = pre[i];
               T postElement = post[i];
               int id = getId(preElement);
               postElement = setId(postElement, id);
               post[i] = postElement;
            }
         }
      }
    
