        [DataMember]
        public string Plaats
        {
            get { return _plaats; }
            set
            {
                if (_plaats != value)
                {
                    _plaats = value;
                    OnPropertyChanged("Plaats");
                }
            }
        }
        private string _plaats;
    
        [DataMember]
        public int LandID
        {
            get { return _landID; }
            set
            {
                if (_landID != value)
                {
                    ChangeTracker.RecordOriginalValue("LandID", _landID);
                    if (!IsDeserializing)
                    {
                        if (Land != null && Land.ID != value)
                        {
                            Land = null;
                        }
                    }
                    _landID = value;
                    OnPropertyChanged("LandID");
                }
            }
        }
        private int _landID;
