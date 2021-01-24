CSharp
{
     public int ODLId { get; set; }
     public string ODLName { get; set; }
     public int? RefODLId { get; set; }
     public virtual VehicleType VehicleType { get; set; }
     public virtual MotorType MotorType { get; set; }
     public virtual GearboxType GearboxType{ get; set; }
     public virtual Door Door { get; set; }
     public virtual VehicleLength VehicleLength { get; set; }
     public string ProjectName { get; set; }
} 
And you will be able to call it like:
CSharp
var odl = ... // get ODL entity from DbSet
odl.VehicleType.Name
odl.GearboxType.SomeProperty
  [1]: https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships#relationships-in-ef
