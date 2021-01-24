    public interface IUserDetails 
    {
        LocalUserDetailList FetchUserDetails(int ID);
    }
    public class GetUserDetailsCloud : IUserDetails {
        public LocalUserDetailList FetchUserDetails(int ID) { 
              CloudWS.UserDetailList userDetailList = cloudWebservice.GetUserDetailList(ID);
              return new LocalUserDetailList(userDetailList);
        }
    }
    
    public class GetUserDetailsPrems : IUserDetails {
        public LocalUserDetailList FetchUserDetails(int ID) { 
              PremsWS.UserDetailList userDetailList = premsWebservice.GetUserDetailList(ID);
              return new LocalUserDetailList(userDetailList);
        }
    }
