    [ServiceContract]
    public interface IRemoteAuth
    {
        [OperationContract]
        public bool CredentialsValid(string login, string hashedPassword)
        {
            return MyDatabaseHelper.IsPasswordValid(login, hashedPassword);
        }
    }
