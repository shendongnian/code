    public class EquatableIntArray : IEquatable<EquatableIntArray>
    {
        public int[] Items { get; set; }
        public EquatableIntArray(int[] Items)
        {
            this.Items = Items;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as EquatableIntArray);
        }
        public bool Equals(EquatableIntArray other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Items != null && (this.Items?.SequenceEqual(other.Items)??false);
        }
        private int? cachedHashCode;
        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;
            int hc = Items.Length;
            for (int i = 0; i < Items.Length; ++i)
            {
                hc = unchecked(hc * 314159 + Items[i]);
            }
            return (cachedHashCode = hc).Value;
        }
    }
