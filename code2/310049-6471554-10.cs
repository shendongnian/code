    class Class2
    {
        public event EventHandler<ProgressEventArgs> ProgressEvent;
        public void Function2(var something)
        {
            OnRaiseProgressEvent(new ProgressEventArgs(1));
        }
    
        protected virtual void OnRaiseProgressEvent(ProgressEventArgs e)
        {
            // C# 6 and above:
            // Raise event if event handler is set (i.e. not null)
            ProgressEvent?.Invoke(this, e);
            // end C# >=6 code
            // C# 5 and earlier:
            EventHandler<ProgressEventArgs> handler = ProgressEvent;
            if(handler != null)
            {
                //this is what actually raises the event.
                handler(this, e);
            }
            // end C# <=5 code
        }
    }
