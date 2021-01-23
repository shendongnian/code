    interface IUsableByPassenger
    {
        MeterReading MeterReading
        {
            get; set;
        }
    }
    interface IUsableByDriver
    {
        Mileage Mileage
        {
            get; set;
        }
    }
    interface IUsableByMechanic : IUsableByDriver
    {
        Engine Engine
        {
            get; set;
        }
    }
    class Car : IUsableByMechanic, IUsableByPassenger
    {
        Mileage IUsableByDriver.Mileage
        {
            // implement mileage access
        }
        Engine IUsableByMechanic.Engine
        {
            // implement engine access
        }
        MeterReading IUsableByPassenger.MeterReading
        {
            // implement engine access
        }
    }
    class Mechanic
    {
        public Mechanic(IUsableByMechanic usable)
        {
            // usable.MeterReading is not here
        }
    }
