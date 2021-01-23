     public delegate void dllFinishedHandler(object sender, SerialDataReceivedEventArgs eventArgs);
        public event dllFinishedHandler DllFinished;
        protected virtual void OnDllFinished(SerialDataReceivedEventArgs e)
        {
            if (DllFinished!= null)
                DllFinished(this, e);
        }
