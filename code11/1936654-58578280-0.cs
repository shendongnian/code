    public class UserAction
    { 
           public int Id{get;set;}
           public int UserId{get;set;}
           public int ClaimId{get;set;}
           public DateTime CreatedOn{get;set;}
           public ActionType Action{get;set;}
           public User User{get; set;}
           public Claim Claim{get;set;}
    }
