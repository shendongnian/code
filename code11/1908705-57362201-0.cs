    class ValueWrapper : IComparable<ValueWrapper>
    {
        public Values Value { get; set; }
        public int Index { get; set; }
        public int CompareTo(ValueWrapper other)
        {
            return this.Value.CompareTo(other.Value) * -1; // Negating since you want reversed order
        }
    }
