    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class InstanceService
    {
        private int _intValue;
        public InstanceService()
        {
            _intValue = 456;
        }
        
        [OperationContract]
        public int GetData()
        {
            return _intValue;
        }
    }
