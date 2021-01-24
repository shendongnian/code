    class IrregularVariableConstThingy
    {
        private int _changeCount = 0;
        private string _value;
        
        public IrregularVariableConstThingy(int maxChangeCount)
        {
            MaxChangeCount = maxChangeCount;
        }
        
        public int MaxChangeCount {get;set;}
        
        public string Value {
            get {
                return _value;
            }
            set {
                if(_changeCount = MaxChangeCount)
                {
                    throw new Exception("Now you can't change my value!");
                }
                _changeCount++;
                _value = value;
            }
        }
    }
