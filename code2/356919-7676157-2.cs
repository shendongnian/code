        public delegate int IdGetter<in T>(T holder);
        public delegate U IdSetter<in T, out U>(T holder, int newId);
 
        private static void RewriteIListIds<T>(
            IList<T> pre,
            IList<T> post,
            IdGetter<T> idGetter,
            IdSetter<T, T> idSetter)
        {
            if (post != null && post.Count > 0)
            {
                //Assert.IsTrue(pre != null && pre.Count > 0);
                for (int i = 0; i < post.Count; i++)
                {
                    T preElement = pre[i];
                    T postElement = post[i];
                    //preElement.Id = postElement.Id;
                    int id = idGetter(postElement);
                    preElement = idSetter(preElement, id);
                    pre[i] = preElement;
                }
            }
        }    
