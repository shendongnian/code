    [InheritanceMapping(Type = typeof(Motorcycle), IsDefault = true, Code = 1)]
    [Table]
    public class Vehicle
    {
        [Column]
        public string Make { get; set; }
    
        [Column]
        public string Model { get; set; }
    
        [Column(IsDiscriminator = true, Name="VehicleTypeId")]
        public VehicleType VehicleType { get; set; }
    }
    
    public class Motorcycle : Vehicle
    {
        // implementation here
    }
