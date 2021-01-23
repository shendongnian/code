    public abstract class Entity
    {
        private int? _cachedHashCode;
        public virtual int EntityId { get; private set; }
        public virtual bool IsTransient { get { return EntityId == 0; } }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var other = obj as Entity;
            return Equals(other);
        }
        public virtual bool Equals(Entity other)
        {
            if (other == null)
            {
                return false;
            }
            if (IsTransient ^ other.IsTransient)
            {
                return false;
            }
            if (IsTransient && other.IsTransient)
            {
                return ReferenceEquals(this, other);
            }
            return EntityId.Equals(other.EntityId);
        }
        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = IsTransient ? base.GetHashCode() : EntityId.GetHashCode();
            }
            return _cachedHashCode.Value;
        }
    }
 
