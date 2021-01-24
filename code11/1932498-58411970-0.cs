    public class Image
    {
        public int Id { get; set; }          // by convention will become the primary key
        public string ImgPath { get; set; }
        // every Images is used by zero or more UserExtendedInfo (one-to-many)
        public virtual ICollection<UserExtendedInfo> UserExtendedInfos {get; set;}
    }
    public class UserExtendedInfo
    {
        public int Id { get; set; }          // by convention will become the primary key
        public string FirstName { get; set; }
        ... // other non-virtual properties
        // Every UserExtendedInfo has exactly one Image, using foreign key
        public int AvatarId {get; set;}
        public virtual Image Avatar { get; set; }
    }
