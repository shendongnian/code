    class DoubleProp
    {
        public delegate int Getter(out double value, out string errorString);
        public delegate int Setter(double value, out string errorString);
        private Getter _getter;
        private Setter _setter;
        public double Value
        {
            get
            {
                CheckErrorCode(
                    _getter(out double value, out string errorString), 
                    errorString
                );
                return value;
            }
            set
            {
                CheckErrorCode(
                    _setter(value, out string errorString), 
                    errorString
                );
            }
        }
        public DoubleProp(Getter getter, Setter setter)
        {
            _getter = getter;
            _setter = setter;
        }
        private void CheckErrorCode(int errorCode, string errorString)
        {
            if (errorCode != 0)
            {
                throw new Exception(errorString);
            }
        }
        // Make getting the value a little prettier...
        public static implicit operator double(DoubleProp dp) => dp.Value;
    }
    /* Usage:
       // Given this Acceleration property...
       public DoubleProp Acceleration { get; set; }
    
       // You could construct it like so provided
       // _device is available...
       Acceleration = new DoubleProp(_device.AC_Get, _device.AC_Set);
    */
     
