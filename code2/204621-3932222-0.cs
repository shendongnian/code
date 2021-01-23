    [ServiceContract]
    public inteface IUserService
    {
        [OperationContract]
        IEnumerable<User> Find(string searchWord);
    }
