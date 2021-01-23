    public class Piano : IComparable<Piano>
    {
        public float Mark { get; set; }
        public int CompareTo(Piano other)
        {
            // The very basic implementation of CompareTo
            if (object.ReferenceEquals(other, null))
                return 1;   // All instances are greater than null
            return Mark.CompareTo(other.Mark);
        }
    }
