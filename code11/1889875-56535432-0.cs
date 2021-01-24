    class TestClass : IComparable<TestClass>
    {
        public int ValueInt { get; set; }
        public char ValueChar { get; set; }
    
        public int CompareTo(TestClass other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
    
            var valueIntComparison = ValueInt.CompareTo(other.ValueInt);
            if (valueIntComparison != 0) return valueIntComparison;
    
            return ValueChar.CompareTo(other.ValueChar);
        }
    }
