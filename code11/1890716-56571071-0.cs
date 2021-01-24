    class LambdaComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> equals;
        private readonly Func<T, int> getHashCode;
    
        public LambdaComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            this.equals = equals;
            this.getHashCode = getHashCode;
        }
    
        public bool Equals(T x, T y) => equals(x, y);
        public int GetHashCode(T obj) => getHashCode(obj);
    }
    var output = users
        .GroupBy(
            x => groupingColumnIndexes.Select(i => x.ColumnValues[i]).ToArray(),
            new LambdaComparer<string[]>((a, b) => a.SequenceEqual(b), x => x.Aggregate(13, (hash, y) => hash * 7 + y?.GetHashCode() ?? 0))
        )
        .Select(g => new User
        {
            Name = g.Key[0],
            LastName = g.Key[1],
            Age = g.Sum(x => int.Parse(x.ColumnValues[2]))
        })
        .ToList();
