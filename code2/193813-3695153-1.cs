    public class Account 
    { 
      private UserAccount _userDetails;
      private UserOtherDetails _otherDetails;
     
      public GetUserAccountDetails(string accountId)
      {
        if (_userDetails == null)
        {
          // This could be a nice place to look at various factory patterns.
          _userDetails = new UserAccount();
          _userDetails.Load(accountId);
        }
        return _userDetails;
      }
      ...
    } 
