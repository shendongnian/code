     public class EventNotifier
    {
        public event EventHandler OnChange;
        private bool _hasChanged;
        public bool HasChanged
        {
            get { return _hasChanged; }
            set
            {
                _hasChanged = value;
                //only need to notify when we've changed. 
                if (value)
                {
                    if (OnChange != null)
                        OnChange(this, EventArgs.Empty);
                }
            }
        }
    }
