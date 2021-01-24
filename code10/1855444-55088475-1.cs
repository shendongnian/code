    public class Vehicle : BusinessLayerBaseNoCSLA<Vehicle, GetVehicleParameters>
    {
        public int VehicleId { get; set; }
        public override void Fetch_Data(GetVehicleParameters parameters)
        {
            //I could cast like  var p = (GetVehicleParameters)BaseParameters; here but something smells bad about that  
            // Note: No need to cast 'parameters' here!
            GetVehicleParameters p = parameters;            
            VehicleId = p.VehicleId;
        }
    }
