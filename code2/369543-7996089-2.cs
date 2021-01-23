    delegate void AcceptPendingChangeHandler(
        object sender,
        AcceptPendingChangeEventArgs e);
    interface IAcceptPendingChange
    {
        AcceptPendingChangeHandler PendingChange;
    }
    class AcceptPendingChangeEventArgs : EventArgs
    {
        public string PropertyName { get; private set; }
        public object NewValue { get; private set; }
        public bool CancelPendingChange { get; set; }
        // flesh this puppy out
    }
    class ViewModelBase : IAcceptPendingChange, ...
    {
        protected virtual bool RaiseAcceptPendingChange(
            string propertyName,
            object newValue)
        {
            var e = new AcceptPendingChangeEventArgs(propertyName, newValue)
            var handler = this.PendingChange;
            if (null != handler)
            {
                handler(this, e);
            }
            return !e.CancelPendingChange;
        }
    }
