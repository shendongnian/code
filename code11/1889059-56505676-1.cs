    public class Usergroup
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
        public List<AccessRight> AccessRights { get; set; }
        public Screen Screen { get; set; }
    }
   
