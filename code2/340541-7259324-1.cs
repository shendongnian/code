    public class RolePublication
    {
        public virtual Role Role {get; set;}
        public virtual Publication Publication {get; set;}
        public virtual bool IsExpired {get; set;}
    }
    public class Role
    {
        ...
        internal protected virtual ICollection<RolePublication> Publications {get; set;}
        public virtual IEnumerable<Publication> CurrentPublications
        { get { return Publications.Where(rp => rp.IsExpired == false).Select(rp => rp.Publication); ) } }
    
        public virtual IEnumerable<Publication> ExpiredPublications
        { get { return Publications.Where(rp => rp.IsExpired == true).Select(rp => rp.Publication); ) } }
    }
