    public class Entity : IEquatable<Entity>
    {
        public bool Equals(Entity other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(null, other))
                return false;
			//if your below implementation will involve objects of derived classes, then do a 
			//GetType == other.GetType comparison
            throw new NotImplementedException("Your equality check here...");
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException("Your lightweight hashing algorithm, consistent with Equals method, here...");
        }
    }
