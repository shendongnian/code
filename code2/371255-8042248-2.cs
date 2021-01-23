    public struct Temperature
    {
        private decimal m_value;
        private const decimal CelsiusToKelvinOffset = 273.15m;
        public static readonly Temperature MinValue = Temperature.FromKelvin(0);
        public static readonly Temperature MaxValue = Temperature.FromKelvin(Decimal.MaxValue);
        public decimal Celsius
        {
            get { return m_value - CelsiusToKelvinOffset; }
        }
        public decimal Kelvin 
        {
            get { return m_value; }
        }
        private Temperature(decimal temp)
        {
            if (temp < Temperature.MinValue.Kelvin)
                   throw new ArgumentOutOfRangeException("temp", "Value {0} is less than Temperature.MinValue ({1})", temp, Temperature.MinValue);
            if (temp > Temperature.MaxValue.Kelvin)
                   throw new ArgumentOutOfRangeException("temp", "Value {0} is greater than Temperature.MaxValue ({1})", temp, Temperature.MaxValue);
             m_value = temp;
        }
        public static Temperature FromKelvin(decimal temp)
        {     
               return new Temperature(temp);
        }
        public static Temperature FromCelsius(decimal temp)
        {
            return new Temperature(temp + CelsiusToKelvinOffset);
        }
        ....
    }
