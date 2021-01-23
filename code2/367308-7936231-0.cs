        public void SetDataType(string value) {
            _dataType = Type.GetType(value); 
        }
        public void SetDataType(Type value) {
            _dataType = value; 
        }
        public Type DataType { get; private set; }  
