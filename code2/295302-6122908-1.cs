    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMyService
    {
        [OperationContract]
        AuthenticationData Authenticate(string username, string password);
    }
