    class ContactEmailComparer : IEqualityComparer < MyClass >
    {
        public bool Equals(MyClass x, MyClass y)
        {
            return x.nbQueen.Equals(y.nbQueen);
        }
    
        public int GetHashCode(MyClass obj)
        {
            return obj.nbQueen.GetHashCode(); // Add or remove other properties as needed.
        }
    }
