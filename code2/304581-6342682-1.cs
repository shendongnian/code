    [ServiceContract]
    public interface IOnlineUsersInfo
    {
        [OperationContract]
        public bool IsUserOnline(string login)
        {
            return MyOnlineUserList.Instance.Any(user => user.Login == login);
        }
    }
