    public class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
    {
        public static readonly ByteArrayEqualityComparer Default = new ByteArrayEqualityComparer();
        private ByteArrayEqualityComparer() { }
        public bool Equals(byte[] x, byte[] y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Length != y.Length)
                return false;
            for (var i = 0; i < x.Length; i++)
                if (x[i] != y[i])
                    return false;
            return true;
        }
        public int GetHashCode(byte[] obj)
        {
            if (obj == null || obj.Length == 0)
                return 0;
            var hashCode = 0;
            for (var i = 0; i < obj.Length; i++)
                // Rotate by 3 bits and XOR the new value.
                hashCode = (hashCode << 3) | (hashCode >> (29)) ^ obj[i];
            return hashCode;
        }
    }
    // ...
    var hc = ByteArrayEqualityComparer.Default.GetHashCode(data);
