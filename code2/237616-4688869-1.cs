    public delegate void dllFinishedHandler(object sender, object tag);
        public event dllFinishedHandler DllFinished;
        protected virtual void OnDllFinished(object e)
        {
            if (DllFinished!= null)
                DllFinished(this, e);
        }
