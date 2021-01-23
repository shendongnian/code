    class MyType : IEquatable<MyType>
    {
        public bool Equals(MyType other)
        {
            // Whatever you want.
        }
    
        public override bool Equals(object other)
        {
            // Presumably you check for null above.
            return Equals(other as MyType);
        }
    }
