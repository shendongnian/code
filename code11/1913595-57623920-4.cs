    public class User
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string StatusMessage { get; set; }
        public List<UserGroups> UserGroups { get; set; }
        public List<Referal> Referals { get; set; }
    }
    public class UserGroups
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
    
    public class Group
    {
        public int GroupId { get; set; }
        public string  GroupName { get; set; }
        public List<UserGroups> UserGroups { get; set; }
    }
    public class Referal
    {
        public int ReferalId { get; set; }
        public string ReferalName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
