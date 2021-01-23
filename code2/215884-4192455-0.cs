    public class Vehicle
    {
        public string Make { get, set };
        public string MakeId { get, set };
    }
    
    ..
    
    List<Vehicle> Vehicles = new List<Vehicle>();
    
    ..
    
    foreach (DataRow dRow in myTable.Rows)
    {
        Vehicles.Add(
            new Vehicle {
                Make = arg.Add(dRow["VehicleMake"]),
                MakeId = arg.Add(dRow["VehicleMakeId"])
            });
    }
