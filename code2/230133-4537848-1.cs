    public struct Velocity
    {
        private readonly double value;
        
        public Velocity(double value)
        {
            this.value = value;
        }
        
        public static implicit operator Velocity(double value)
        {
            return new Velocity(value);
        }
        
        public static Velocity operator +(Velocity first, Velocity second)
        {
            return new Velocity(first.value + second.value);
        }
    
        public static Velocity operator -(Velocity first, Velocity second)
        {
            return new Velocity(first.value - second.value);
        }
        // TODO: Overload == and !=, implement IEquatable<T>, override
        // Equals(object), GetHashCode and ToStrin
    }
    
    class Test
    {
        static void Main()
        {
            Velocity ms = 0;
            ms = 17.4;
            // The statement below will perform a conversion of 9.8 to Velocity,
            // then call +(Velocity, Velocity)
            ms += 9.8;
        }
    }
