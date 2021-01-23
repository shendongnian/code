    public abstract class UnitOfMeasure {}
    
    public abstract class Temperature:UnitOfMeasure {
    public static CelsiusTemperature Celsius {get{return new CelsiusTemperature();}}
    public static FahrenheitTemperature Fahrenheit {get{return new CelsiusTemperature();}}
    public static KelvinTemperature Kelvin {get{return new CelsiusTemperature();}}
    }
    public class CelsiusTemperature:Temperature{}
    public class FahrenheitTemperature :Temperature{}
    public class KelvinTemperature :Temperature{}
    ...
    public class UnitConverter
    {
       public UnitOfMeasure BaseUnit {get; private set;}
       public UnitConverter(UnitOfMeasure baseUnit) {BaseUnit = baseUnit;}
       private readonly Dictionary<UnitOfMeasure, Func<decimal, decimal>> converters
          = new Dictionary<UnitOfMeasure, Func<decimal, decimal>>();
       public void AddConverter(UnitOfMeasure measure, Func<decimal, decimal> conversion)
       { converters.Add(measure, conversion); }
       public void Convert(UnitOfMeasure measure, decimal input)
       { return converters[measure](input); }
    }
