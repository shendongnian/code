    class Foo // Class and member names must be distinct
    {
        public delegate void ADelegate();
        public event ADelegate A;
        private void OnA()
        {
            if (A == null) return;
            // There may be multiple subscribers, invoke each separately.
            foreach(ADelegate del in A.GetInvocationList())
                del.BeginInvoke(SubscriberCallback, null);
        }
        private void SubscriberCallback(IAsyncResult result)
        {
            A.EndInvoke(result);
            // Do something in the callback...
        }
        public void Func()
        {
            // Some code...
            OnA();
            // More code...
        }
    }
