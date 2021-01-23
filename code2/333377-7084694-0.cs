    public class ABS : IEquatable<string>
    {
        string A, B;
        public bool Equals(string other)
        {
            return A.Equals(other) || B.Equals(other);
        }
    }
