    public enum TemperatureScale
    {
       Celsius,
       Fahrenheit,
       Kelvin
    }
    
    public struct Temperature
    {
       decimal Degrees {get; private set;}
       TemperatureScale Scale {get; private set;}
       public Temperature(decimal degrees, TemperatureScale scale)
       {
           Degrees = degrees;
           Scale = scale;
       }
       public Temperature(Temperature toCopy)
       {
           Degrees = toCopy.Degrees;
           Scale = toCopy.Scale;
       }
    }
