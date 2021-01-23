    public class SomeClass : IEquatable<SomeClass>
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public int[] NumberList { get; set; }
        public bool Equals(SomeClass other)
        {
            // whatever your custom equality logic is
            return other.Name == Name &&
                other.Value == Value &&
                other.NumberList == NumberList;
        }
    }
