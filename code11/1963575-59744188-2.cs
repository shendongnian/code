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
    
    var converter = new HeterogenousListConverter<IVehicle, ObservableCollection<IVehicle>>(
        (nameof(Car),     typeof(Car)),
        (nameof(Bicycle), typeof(Bicycle))
    );
    
    var options = new JsonSerializerOptions();
    options.Converters.Add(converter);
    
    var vehicles = JsonSerializer.Deserialize<ObservableCollection<IVehicle>>(json, options);
    Console.Write($"{vehicles.Count} Vehicles: {String.Join(", ",  vehicles.Select(v => v.ToString())) }");
    
    var json2 = JsonSerializer.Serialize(vehicles, options);
    Console.WriteLine(json2);
    
    Console.WriteLine($"Completed at {DateTime.Now}");
