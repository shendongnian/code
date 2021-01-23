    public class SiteUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string AvatarUrl { get; set; }
        public int TimezoneUtcOffset { get; set; }
        // Any other data I need...
    }
