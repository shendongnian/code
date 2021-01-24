    class FooEqualityComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo one, Foo two)
        {
            // your implementation goes here
            // where you for instance compare Exo
        }
    
        public int GetHashCode (Foo foo)
        {
            // your implementation goes here
        }
    }
