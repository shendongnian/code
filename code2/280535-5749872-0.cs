    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ICatchAll
    {
        [OperationContract(IsOneWay = false, Action = "*", ReplyAction = "*")]
        Message ProcessMessage(Message message);
    }
