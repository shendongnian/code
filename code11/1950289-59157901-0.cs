csharp
class Car
{
    private static Dictionary<CarCollection, Car> _availableCars = 
        new Dictionary<CarCollection, Car>()
        {
             {CarCollection.Audi, new Car("Ceat", "Audi X")},
             {CarCollection.BMW, new Car("ABCD", "BMW Y")},
        }
    static Car GetCar(CarCollection carName)
    {
        if(_availableCars.TryGetValue(carName, out var car))
        {
            return car;
        }
        // or throw an exception or something like that.
        return null; 
    }
    // Private constructor - 
    // don't let an outsider create an instance that's not in the dictionary.
    private Car(string tyreName, string carName)
    {
        TyreName = tyreName,
        CarName = carName
    }
    public string TyreName {get;}
    public string CarName {get;}
}
If you want to, you can make the car properties read/write, so whomever is using this code can set different values to them.
