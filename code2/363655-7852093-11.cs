    //The only functionality any UnitOfMeasure needs is to be semantically equatable
    //with any other reference to the same type.
    public abstract class UnitOfMeasure:IEquatable<UnitOfMeasure> 
    { 
       public override bool Equals(UnitOfMeasure other)
       {
          return this.ReferenceEquals(other)
             || this.GetType().Name == other.GetType().Name;
       }
       public override bool Equals(Object other) 
       {
          return other is UnitOfMeasure && this.Equals(other as UnitOfMeasure);
       }    
       public override operator ==(Object other) {return this.Equals(other);}
       public override operator !=(Object other) {return this.Equals(other) == false;}
       
    }
    
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
