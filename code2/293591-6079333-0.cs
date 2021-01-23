    public class ThreeLevelDictionary<TValue> : Dictionary<Tuple<string, string, string>, TValue>
    {
        public void Add(string s1, string s2, string s3, TValue value)
        {
            Add(Tuple.Create(s1, s2, s3), value);
        }
        public TValue this[string s1, string s2, string s3]
        {
            get { return this[Tuple.Create(s1, s2, s3)]; }
            set { value = this[Tuple.Create(s1, s2, s3)]; }
        }
        public void Remove(string s1, string s2, string s3)
        {
            Remove(Tuple.Create(s1, s2, s3);
        }
        public IEnumerable<string> FindKeys(TValue value)
        {
            foreach (var key in Keys)
            {
                if (EqualityComparer<TValue>.Default.Equals(this[key], value))
                    return new string[] { key.Item1, key.Item2, key.Item3 };
            }
            throw new InvalidOperationException("missing value");
        }
    }
