    public class PlayerBowlerTypeId
    {
        public virtual int PlayerId { get; set; }
        public virtual int BowlerTypeId { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as PlayerBowlerTypeId);
        }
        private bool Equals(PlayerBowlerTypeId other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PlayerId == other.PlayerId &&
                BowlerTypeId == other.BowlerTypeId;
        }
        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ PlayerId.GetHashCode();
                hash = (hash * 31) ^ BowlerTypeId.GetHashCode();
                return hash;
            }
        }
    }
    public class PlayerBowlerType
    {
        public PlayerBowlerType()
        {
            Id = new PlayerBowlerTypeId();
        }
        public virtual PlayerBowlerTypeId Id { get; set; }
    }
    public class PlayerBowlerTypeMap : ClassMap<PlayerBowlerType>
    {
        public PlayerBowlerTypeMap()
        {
            Table("TABLENAME");
            CompositeId<PlayerBowlerTypeId>(x => x.Id)
                .KeyProperty(x => x.BowlerTypeId, "COLUMNNAME")
                .KeyProperty(x => x.PlayerId, "COLUMNNAME");
        }
    }
