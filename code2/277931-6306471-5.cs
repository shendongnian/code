    public abstract class Organization : Entity<int>
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Organization object1, Organization object2)
        {
            return AreEqual(object1, object2);
        }
        public static bool operator !=(Organization object1, Organization object2)
        {
            return AreNotEqual(object1, object2);
        }
    }
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; /*protected*/ set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }
        private static bool IsTransient(Entity<TId> obj)
        {
            return obj != null &&
            Equals(obj.Id, default(TId));
        }
        private Type GetUnproxiedType()
        {
            return GetType();
        }
        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!IsTransient(this) &&
            !IsTransient(other) &&
            Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                otherType.IsAssignableFrom(thisType);
            }
            return false;
        }
        public override int GetHashCode()
        {
            if (Equals(Id, default(TId)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }
        /// This method added by me
        /// For == overloading
        protected static bool AreEqual<TEntity>(TEntity entity1, TEntity entity2)
        {
            if ((object)entity1 == null)
            {
                return ((object)entity2 == null);
            }
            else
            {
                return entity1.Equals(entity2);
            }
        }
        /// This method added by me
        /// For != overloading
        protected static bool AreNotEqual<TEntity>(TEntity entity1, TEntity entity2)
        {
            return !AreEqual(entity1, entity2);
        }
    }
