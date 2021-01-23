    public class BusinessClass
    {
        private ISomeServiceClient _svc;
        public BusinessClass(ISomeServiceClient svc)
        {
            _svc = svc;
        }
        public void SendData(DataUnit dataUnit)
        {
           _svc.SomeMethod(dataUnit);
        }
    }
