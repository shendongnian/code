    public class Car
    {
        public Color Color {get; set;}
        public int NumberOfDoors {get; set;}        
    }
    public class CarJson
    {
        public string color {get; set;}
        public string numberOfDoors { get; set; }
        public static implicit operator Car(CarJson json)
        {
            return new Car
                {
                    Color = (Color) Enum.Parse(typeof(Color), json.color),
                    NumberOfDoors = Convert.ToInt32(json.numberOfDoors)
                };
        }
    }
