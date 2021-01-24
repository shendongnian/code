public IEnumerable<Vehicles> CaliEmissionStd()
{
    return from a in EPA.RoadVehicles
           where a.emissions.CaliEmissions == true
           select a;
}
public IEnumerable<Vehicles> Cars(IEnumerable<Vehicles> vehicles)
{
    return from a in vehicles
           where a.VehType == "Car"
           select a;
}
Here, we have a method that selects all road vehicles with cali emission standard, and a filter that selects a sublist of type car.
Since LINQ holds off on constructing a query until we enumerate it, we can do the following so that we end up with a single SQL query, which queries the database and will only returns the rows that are relevant.
var AutosWithCaliEmissionStd = Cars(CaliEmissionStd());
But if we had returned a List from ```CaliEmissionStd()```, then it would  run slower because the database would be returning data for all vehicles with cali emission standard(Cars, SUV, Trucks, Motorcycles, etc), instead of just Cars, causing us to waste cycles/time doing the filtering in the client.
