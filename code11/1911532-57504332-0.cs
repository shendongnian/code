    public class User
    {
        //....omitted
        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
    public class UserTeam
    {      
        public int UserId{ get; set; }
        public User User { get; set; }
        public int TeamId{ get; set; }
        public Team Team{ get; set; }
    }
    public class Team
    {
        //.... omitted
        public virtual ICollection<UserTeam> UserTeams{ get; set; }
    }
