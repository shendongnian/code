    /// <summary>
    /// Temperature class that uses a base unit of Celsius
    /// </summary>
    public struct Temp
    {
        public static Temp FromCelsius(double value)
        {
            return new Temp(value);
        }
        public static Temp FromFahrenheit(double value)
        {
            return new Temp((value - 32) * 5 / 9);
        }
        public static Temp FromKelvin(double value)
        {
            return new Temp(value - 273.15);
        }
        public static Temp operator +(Temp left, Temp right)
        {
            return Temp.FromCelsius(left.Celsius + right.Celsius);
        }
        private double _value;
        private Temp(double value)
        {
            _value = value;
        }
        public double Kelvin
        {
            get { return _value + 273.15; }
        }
        public double Celsius
        {
            get { return _value; }
        }
        public double Fahrenheit
        {
            get { return _value / 5 * 9 + 32; }
        }
    }
