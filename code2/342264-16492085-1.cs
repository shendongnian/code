    public class Piano : IComparable<Piano>, IComparable
    {
        public int CompareTo(Piano other) { ... }
        ...
        public int CompareTo(object obj)
        {
            if (obj != null && !(obj is Piano))
                throw new ArgumentException("Object must be of type Piano.");
            return CompareTo(obj as Piano);
        }
    }
