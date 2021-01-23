    class TypeWithEvents
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // You want the set method to automatically
        // raise the PropertyChanged event via some
        // special code in the EventRaisingType class?
        public EventRaisingType Property { get; set; }
    }
