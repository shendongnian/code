    [ServiceContract]
    public interface IMyService
    {
      [OperationContract]
      [FaultContract(typeof(FaultContracts.GetMyObjectFault))]
      MyObject GetMyObject(string param1, string param2);
    }
    
    [ExceptionShielding("GetMyObjectServicePolicy")]
    public class MyService : IMyService
    {
        private QueryHandler _queryHandler;
    
        public MyService()
        {
            _queryHandler = new QueryHandler();
        }
    
        public MyObject GetMyObject(string param1, string param2)
        {
            return _queryHandler.GetMyObject(param1, param2);
        }
    }
