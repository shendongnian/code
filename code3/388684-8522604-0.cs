    public sealed partial class Computer
    {
        // This event is fired every time when Online is changed
        public event EventHandler OnlineChanged;
    
        private bool _online;
        public bool Online
        {
            get { return _online; }
            set
            {
                // Exit if online value isn't changed
                if (_online == value) return;
    
                _online = value;
                RaiseProperty("Online");
    
                // Raise additional event only if there are any subscribers
                if (OnlineChanged != null)
                    OnlineChanged(this, null);
            }
        }
    }
