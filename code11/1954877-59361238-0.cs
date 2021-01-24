    [Serializable]
    public class Farba : IComparable<Farba>
    {
        ...
        public int CompareTo(Farba other)
        {
            return ObliczCene().CompareTo(other.ObliczCene());
        }
    
