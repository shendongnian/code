    public class Starport
    {
        public string Name { get; protected set; }
        public double MaximumShipSize { get; protected set; }
        public AircarfDispatcher GetDispatcherOnDuty() {
            return new AircarfDispatcher(this); // It can be decoupled further, just example
        }
    }
    
    public class Spaceship
    {
        public double Size { get; private set; };
        public Starport Home {get; protected set;};
    }
    public class AircarfDispatcher
    {
        Startport readonly airBase;
        public AircarfDispatcher(Starport airBase) { this.airBase = airBase; }
        public bool CanLand(Spaceship ship) {
            if (ship.Size > airBase.MaximumShipSize)
                return false;
            return true;
        }
        public bool CanTakeOff(Spaceship ship) {
            return true;
        }
        public bool Land(Spaceship ship) {
            var canLand = CanLand(ship);
            if (!canLand)
                throw new ShipLandingException(airBase, this, ship, "Not allowed to land");
            // Do something with the capacity of Starport
        }
    }
    
    
    // Try to land my ship to the first available port
    var ports = GetPorts();
    var onDuty = ports.Select(p => p.GetDispatcherOnDuty())
        .Where(d => d.CanLand(myShip)).First();
    onDuty.Land(myShip);
    // try to resize! But NO we cannot do that (setter is protected)
    // because it is not the responsibility of the Port, but a building company :)
    ports.First().MaximumShipSize = ports.First().MaximumShipSize / 2.0
