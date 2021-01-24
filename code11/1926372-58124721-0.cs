    public class LocalUserDetailList
    {
        public [[ underlying name and type for the UserList data ]] { get; set; }
        public LocalUserDetailList(PremsWS.UserDetailList UserDetailList)
        {
            // populate the publicly available list above^
        }
        public LocalUserDetailList(CloudWS.UserDetailList UserDetailList)
        {
             // populate the publicly available list above^
        }
    }
