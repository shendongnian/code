    public class FahrenheitToCelciusConverter : ITemperatureConverter
    {
        public int Convert(int source)
        {
             // put your code here
        }
        public TempatureUnit SourceUnit {get { return TemperatureUnit.Fahrenheit; }}
        public TempatureUnit TargetUnit {get { return TemperatureUnit.Celcius; }}
    }
