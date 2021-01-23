    public class NeighborHood
    {
        public virtual User User { get; set; }
        public virtual Place Place { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual bool Selected { get; set; }
        public override bool Equals(object obj)
        {
           //check here to make sure these objects are equal (user_id and place_id are the same)    
        }
        public override int GetHashCode()
        {
            return User.Id.GetHashCode() ^ Place.Id.GetHashCode();
        }
    }
