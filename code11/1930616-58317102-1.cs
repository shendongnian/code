    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; } // -1 = deleted, 0 = incomplete, 1 = completed (signup)
        public List<Member> Captain { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Captain { get; set; }
        public int Status { get; set; } // -1 = deleted, 0 = inactive, 1 = active
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
