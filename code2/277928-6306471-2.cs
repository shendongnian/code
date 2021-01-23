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
