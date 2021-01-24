    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    
    #nullable disable
    
    public interface IVehicle { }
    
    public class Car : IVehicle {
        public string make          { get; set; } = null;
        public int    numberOfDoors { get; set; } = 0;
        
        public override string ToString()
            => $"{make} with {numberOfDoors} doors";
    }
    
    public class Bicycle : IVehicle{
        public int frontGears { get; set; } = 0;
        public int backGears  { get; set; } = 0;
    
        public override string ToString()
            => $"{nameof(Bicycle)} with {frontGears * backGears} gears";
    }
    
    public class VehicleConverter : JsonConverter<IEnumerable<IVehicle>>{
    
        public override bool CanConvert(Type typeToConvert)
            => typeof(IEnumerable<IVehicle>).IsAssignableFrom(typeToConvert);
    
        public override IEnumerable<IVehicle> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options){
            // Helper function for validating where you are in the JSON    
            void validateToken(Utf8JsonReader reader, JsonTokenType tokenType){
                if(reader.TokenType != tokenType)
                    throw new JsonException($"Invalid token: Was expecting a '{tokenType}' token but received a '{reader.TokenType}' token");
            }
    
            validateToken(reader, JsonTokenType.StartArray);
            var results = new List<IVehicle>();
        
            reader.Read(); // Advance to the first object after the StartArray token. This should be either a StartObject token, or the EndArray token. Anything else is invalid.
            
            while(reader.TokenType == JsonTokenType.StartObject){ // Start of 'wrapper' object
            
                reader.Read(); // Move to property name
                validateToken(reader, JsonTokenType.PropertyName);
    
                var propertyName = reader.GetString();
                
                reader.Read(); // Move to start of object (stored in this property)
                validateToken(reader, JsonTokenType.StartObject); // Start of vehicle
    
                switch(propertyName){
                
                    case nameof(Car):
                        var car = (IVehicle)JsonSerializer.Deserialize(ref reader, typeof(Car), options);
                        results.Add(car);
                        break;
                        
                    case nameof(Bicycle):
                        var bicycle = (IVehicle)JsonSerializer.Deserialize(ref reader, typeof(Bicycle), options);
                        results.Add(bicycle);
                        break;
                        
                    default:
                        reader.Skip();
                        break;
                }
                reader.Read(); // Move past end of vehicle object
                reader.Read(); // Move past end of 'wrapper' object
            }
    
            validateToken(reader, JsonTokenType.EndArray);
    
            return results;
        }
    
        public override void Write(Utf8JsonWriter writer, IEnumerable<IVehicle> vehicles, JsonSerializerOptions options){
    
            writer.WriteStartArray();
    
            foreach (var vehicle in vehicles){
    
                writer.WriteStartObject();
    
                switch (vehicle) {
    
                    case Car car:
                        writer.WritePropertyName(nameof(Car));
                        JsonSerializer.Serialize(writer, car, options);
                        break;
    
                    case Bicycle bicycle:
                        writer.WritePropertyName(nameof(Bicycle));
                        JsonSerializer.Serialize(writer, bicycle, options);
                        break;
                }
    
                writer.WriteEndObject();
            }
    
            writer.WriteEndArray();
        }
    }
    
    string json = @"[
      {
        ""Car"": {
          ""make"": ""Smart"",
          ""numberOfDoors"": 2
        }
      },
      {
        ""Car"": {
          ""make"": ""Lexus"",
          ""numberOfDoors"": 4
        }
      },
      {
        ""Bicycle"": {
          ""frontGears"": 3,
          ""backGears"": 6
        }
      }
    ]";
    
    var options = new JsonSerializerOptions();
    options.Converters.Add(new VehicleConverter());
    
    var vehicles = JsonSerializer.Deserialize<IEnumerable<IVehicle>>(json, options);
    
    foreach(var vehicle in vehicles)
        Console.WriteLine(vehicle);
    
    Console.WriteLine($"Completed at {DateTime.Now}");
