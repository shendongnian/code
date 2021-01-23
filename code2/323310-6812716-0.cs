    [ServiceContract]
    [ServiceKnownType(typeof(MyDerivedObject))]
    interface IEvent
    {
        [OperationContract(IsOneWay = true)]
        void OnEvent(string serverName, string changeType, List<myObject> myObjects);
    }
