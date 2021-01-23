    public struct ImplicitNullable<T> where T: struct
    {
        public bool HasValue { get { return this._value.HasValue; } }
        public T Value { get { return this._value.Value; } }
        public ImplicitNullable(T value) : this() { this._value = value; }
        public ImplicitNullable(Nullable<T> value) : this() { this._value = value; }
        public static implicit operator ImplicitNullable<T>(T value) { return new ImplicitNullable<T>(value); }
        public static implicit operator ImplicitNullable<T>(Nullable<T> value) { return new ImplicitNullable<T>(value); }
        public static implicit operator T(ImplicitNullable<T> value) { return value._value ?? default(T); }
        public static implicit operator Nullable<T>(ImplicitNullable<T> value) { return value._value; }
        private Nullable<T> _value { get; set; }
        
        // Should define other Nullable<T> members, especially 
        // Equals and GetHashCode to avoid boxing
    }
