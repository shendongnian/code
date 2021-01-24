     public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this._fuelConsumption = fuelConsumption;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        private double _fuelConsumption { get;  set; }
        public double FuelConsumption {
            get { return _fuelConsumption; }
            protected set {
                _fuelConsumption = (_fuelConsumption + 0.9);
            } }
        public abstract string Drive(double distance);
        public abstract void Refuel(double liters);
    }
