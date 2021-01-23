    public class FailureEventArgs : EventArgs // not the best name, I know
    {
        private bool _failed;
        public bool Failed
        {
            get { return _failed; }
            set { _failed |= value; }
        }
    }
