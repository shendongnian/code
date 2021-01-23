    class MyEqualityComparer : IEqualityComparer<Comment>
    {
        public bool Equals(Comment x, Comment y)
        {
            return x.Sender.Equals(y.Sender);
        }
        public int GetHashCode(Comment obj)
        {
            return obj.Sender.GetHashCode();
        }
    }
