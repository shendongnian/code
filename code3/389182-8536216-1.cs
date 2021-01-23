    public class PostComparer : IEqualityComparer<Post>
    {
        #region IEqualityComparer<Post> Members
    
        public bool Equals(Post x, Post y)
        {
            return x.Id.Equals(y.Id);
        }
    
        public int GetHashCode(Post obj)
        {
            return obj.Id.GetHashCode();
        }
    
        #endregion
    }
