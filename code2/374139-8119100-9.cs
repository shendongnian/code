    public class PlaceAndTemperature 
    {
         public PlaceAndTempature(string name, int temperature)
         {
             Name = name;
             Temperature = temperature;
         }
         public string Name { get; private set; } 
         public int Temperature { get; private set; } 
         public PlaceAndTemperature Convert(ITemperatureConverter converter)
         {
             return new PlaceAndTemperature(Name, converter.Convert(Temperature));
         }
    }
