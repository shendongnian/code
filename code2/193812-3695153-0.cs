    public class Account 
    { 
      public UserAccount UserDetails {get; private set;}
      public UserOtherDetails OtherDetails {get; private set;} 
     
      public Account (UserAccount userDetails, UserOtherDetails otherDetails)
      {
        this.UserDetails = userDetails;
        this.OtherDetails = otherDetails;
      }
    } 
