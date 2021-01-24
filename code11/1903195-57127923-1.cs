    public class VehicleDecorator : Vehicle
      public VehicleDecorator(Vehicle vehicle)
      {
          this.vehicle = vehicle;
      } 
    public class VehicleWithAc : VehicleDecorator
      public VehicleWithAc(Vehicle vehicle) : base(vehicle){}
      public override double FuelConsumption { 
                   get{
                         return base.FuelConsumption+0.9 } }
