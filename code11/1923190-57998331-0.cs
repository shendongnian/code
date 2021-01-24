    public class MyObject
    {
        private int? type;
        private string[] attrs;
        public override int GetHashCode()
            => HashCode.Combine(type, attrs);
        // remember to also override Equals
    }
