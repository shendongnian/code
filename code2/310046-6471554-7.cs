    class Class2
    {
        public event EventHandler<ProgressEventArgs> ProgressEvent;
        public static void Function2(var something)
        {
            OnRaiseProgressEvent(new ProgressEventArgs(1);
        }
    
        protected virtual void OnRaiseProgressEvent(ProgressEventArgs e)
        {
            EventHandler<ProgressEventArgs> handler = ProgressEvent;
            if(handler != null)
            {
                //this is what actually raises the event.
                handler(this, e);
            }
        }
    }
