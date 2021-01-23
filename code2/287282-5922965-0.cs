    class Program
    {
        static void Main(string[] args)
        {
            DoStuffService svc = new DoStuffService();
            svc.Start();
            // stuff...
            svc.DelayTilDone();
        }
    }
    public class DoStuffService
    {
        Task _t;
        public void Start()
        {
            _t = Task.Factory.StartNew(() => { LongRunningOperation(); });
        }
        public void DelayTilDone()
        {
            if (_t==null) return;
            _t.Wait();
        }
        private void LongRunningOperation()
        {
            System.Threading.Thread.Sleep(6000);
            System.Console.WriteLine("LRO done");
        }
    }
