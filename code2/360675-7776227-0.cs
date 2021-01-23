    public class Person
    {
        private string _name;
        private string _phone;
    
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
    
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                //Invoke the Handlers now
                OnPhoneChanged();
            }
        }
    
        protected EventHandlerList EventDelegateCollection = new EventHandlerList();
        static readonly object PhoneChangedEventKey = new object();
        public event EventHandler PhoneChanged
        {
            add
            {
                EventDelegateCollection.AddHandler(PhoneChangedEventKey, value);
            }
            remove
            {
                EventDelegateCollection.RemoveHandler(PhoneChangedEventKey, value);
            }
        }
    
        private void OnPhoneChanged()
        {
            EventHandler subscribedDelegates = (EventHandler)this.EventDelegateCollection[PhoneChangedEventKey];
            subscribedDelegates(this, EventArgs.Empty);
        }
    }
