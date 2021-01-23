    public class Trucks : Vehicles<Truck>
    {    
    }    
    
    public class Vehicles<T> : IEnumerable<T>
        where T : Vehicle
    {    
    }    
    
    public class Vehicle { }
    
    public class Truck : Vehicle { }
