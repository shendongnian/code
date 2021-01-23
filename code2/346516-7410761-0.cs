    public class ComparableDictionary : Dictionary<string, List<int>>
    {
        private const int CouldBeAnyConstant = 392;
        public override bool Equals(object other)
        {
            return Equals((ComparableDictionary)other);
        }
        public bool Equals(ComparableDictionary other)
        {
            return other != null && (GetHashCode() == other.GetHashCode());
        }
        public override int GetHashCode()
        {
            int result = CouldBeAnyConstant;
            unchecked
            {
                foreach (var list in Values)
                    foreach (var value in list)
                        result = result*value.GetHashCode();
                foreach (var value in Keys)
                    result = result * value.GetHashCode();
            }
            return result;
        }
