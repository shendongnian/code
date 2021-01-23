    public ObjectB
    {
        private ObjectA _objectA;
        public  ObjectA objectA
        {
            get 
            { 
                return _objectA; 
            }
            set
            {
                if (value != _objectA)
                {
                    _objectA = value;
                    RaiseObjectAChanged(/* sender, args */);
                }
            }
        }
        private RaiseObjectAChanged()
        {
            // raise event here
        }
        private OnObjectAChanged()
        {
            // event handler
        }
    }
