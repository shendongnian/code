    public class UserToDoId
    {
        User UserIdPart { get; set; }
        Achievement AchievementIdPart { get; set; }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as UserToDoId);
        }
        private bool Equals(UserToDoId other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return UserIdPart.ID == other.UserIdPart.ID &&
                MissionIdPart.ID == other.MissionIdPart.ID;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ UserIdPart.ID.GetHashCode();
                hash = (hash * 31) ^ MissionIdPart.ID.GetHashCode();
                return hash;
            }
        }
    }
