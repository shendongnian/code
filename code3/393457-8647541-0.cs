    class MyEqualityComparer : IEqualityComparer<News>
    {
        public bool Equals(News x, News y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(News obj)
        {
            return obj.Id.GetHashCode();
        }
    }
