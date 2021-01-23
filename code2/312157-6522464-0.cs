    public class Consumer
    {
        public void SomeMethod()
        {
            using (WCFClient client = new WCFClient(new WCFService()))
            {
                int sum = client.Add(5, 10);
            }
        }
    }
    public class WCFClient : IDisposable
    {
        private WCFService _service;
        public WCFClient(WCFService service)
        {
            _service = service;
        }
        public int Add(int a, int b)
        {
            return _service.Add(a, b);
        }
        public void Dispose()
        {
            if (_service != null)
                _service.Close();
        }
    }
