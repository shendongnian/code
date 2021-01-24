    public class SomeClass
    {
        public string SomeString { get; set; }
        public int SomeInt { get; set; }
    }
    public class SomeClassComparer : IEqualityComparer<SomeClass>
    {
        public bool Equals(SomeClass x, SomeClass y)
        {
            return x.SomeInt.Equals(y.SomeInt);
        }
        public int GetHashCode(SomeClass obj)
        {
            return obj.SomeInt.GetHashCode();
        }
    }
