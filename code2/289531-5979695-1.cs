    class Foo // Class and member names must be distinct
    {
        public delegate void ADelegate();
        public event ADelegate A;
        private void OnA()
        {
            if (A != null)
                A.BeginInvoke(SubscriberCallback, null);
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
