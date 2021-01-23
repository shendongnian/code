        public CarrierOperations _string;
        public int _int;     
        public CarrierOperations OperationName
        {
            get { return _string; }
            set { _string = value; }
        }
        public int LoadPortID
        {
            get { return _int; }
            set { _int = value; }
        }
        public Node(CarrierOperations _s, int _v)
        {
            _string = _s;
            _int = _v;         
        }           
    }
