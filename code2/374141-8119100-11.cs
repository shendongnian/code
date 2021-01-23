    public interface ITemperatureConverter 
    {
        int Convert(int source);
        TempatureUnit SourceUnit {get;}
        TempatureUnit TargetUnit {get;}
    }
    public class PlaceAndTemperature 
    {
         public PlaceAndTempature(string name, int temperature, TempatureUnit unit)
         {
             Name = name;
             Temperature = temperature;
             TempatureType = unit;
         }
         public string Name { get; private set; } 
         public int Temperature { get; private set; } 
         public TempatureUnit TemperatureType {get; private set; }
         public PlaceAndTemperature Convert(ITemperatureConverter converter)
         {
             return new PlaceAndTemperature(Name, converter.Convert(Temperature), converter.TargetUnit);
         }
    }
