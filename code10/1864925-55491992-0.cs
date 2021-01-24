    public class CustomEqualityComparer : IEqualityComparer<DataRow>
    {
        private readonly List<string> groupFields;
        public CustomEqualityComparer(List<string> groupFields)
        {
            this.groupFields = groupFields;
        }
        public bool Equals(DataRow x, DataRow y)
        {
            var xCols = groupFields.Select(f => x[f]);
            var yCols = groupFields.Select(f => y[f]);
            var pairs = xCols.Zip(yCols, (v1, v2) => (v1, v2));
            return pairs.All(p => p.Item1.Equals(p.Item2));
        }
        public int GetHashCode(DataRow obj)
        {
            return 42; // force Equals call
        }
    }
