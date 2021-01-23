    class Foo // Class and member names must be distinct
    {
        public delegate void ADelegate();
        public event ADelegate A;
        private IAsyncResult OnA()
        {
            if (A != null)
                return A.BeginInvoke(SubscriberCallback, null);
            return null;
        }
        private void SubscriberCallback(IAsyncResult result)
        {
            A.EndInvoke(result);
            // Do something in the callback...
        }
        public void Func()
        {
            // Some code...
            var res = OnA();
            // More code...
            if(res != null && !res.IsCompleted)
                A.EndInvoke(res);
        }
    } 
