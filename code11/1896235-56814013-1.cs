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
                int errorCode = _getter(out double value, out string errorString);
                if (errorCode != 0)
                {
                    throw new Exception(errorString);
                }
                return value;
            }
            set
            {
                int errorCode = _setter(value, out string errorString);
                if (errorCode != 0)
                {
                    throw new Exception(errorString);
                }
            }
        }
        public DoubleProp(Getter getter, Setter setter)
        {
            _getter = getter;
            _setter = setter;
        }
        // Make getting the value a little prettier...
        public static implicit operator double(DoubleProp dp) => dp.Value;
    }
    /* Usage (with assumptions):
       public DoubleProp Acceleration { get; set; }
           = new DoubleProp(_device.AC_Get, _device.AC_Set);
    */
     
