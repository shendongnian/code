    using System.Text.Json;
    using Dahomey.Json
    public class Car
    {
        public int Year { get; set; } // does serialize correctly
        public string Model; // will serialize correctly
    }
    
    static void Problem() {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.SetupExtensions(); // extension method to setup Dahomey.Json extensions
    
        Car car = new Car()
        {
            Model = "Fit",
            Year = 2008,
        };
        string json = JsonSerializer.Serialize(car, options); // {"Year":2008,"Model":"Fit"}
        Car carDeserialized = JsonSerializer.Deserialize<Car>(json);
    
        Console.WriteLine(carDeserialized.Model); // Fit
    }
