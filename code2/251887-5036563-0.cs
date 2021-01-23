     private List<EventType> _eventTypes;
     public List<EventType> EventTypes
        {
            get { return _eventTypes; }
            set
            {
                _eventTypes = value;
                RaisePropertyChanged("EventTypes");
            }
        }
