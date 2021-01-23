    public class Test : IEquatable<Test>
    { 
        /// <summary>
        /// The unique identifier for this Test entity, or zero if this
        /// Test entity has not yet been serialized to the database.
        /// </summary>
        public int Id { get; private set; } 
        public string Something { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Test);
        }
        public bool Equals(Test other)
        {
            if (other == null)
                return false;
            // Distinct entities may exist with the Id value of zero.
            if (Id == 0)
                return object.ReferenceEquals(this, other);
            return Id == other.Id;
        }
        /// <summary>
        /// Gets a hash code for this Test entity. Warning: an instance with
        /// an Id of zero will change its identity when saved to the DB. Use with care.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return Id;
        }
    } 
