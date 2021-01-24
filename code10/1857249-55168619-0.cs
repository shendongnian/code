    public class GenericObject
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public UserObject UserWhoGeneratedThisObject { get; set; }
    }
    public class UserObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
