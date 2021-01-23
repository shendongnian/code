    public class Car :Vehicle
    {
    }
    private void doSomething1(IEnumerable<Vehicle> vehicles)
    {
            
    }
    private void doSomething2(List<Vehicle> vehicles)
    {
            
    }
    var vec = new List<Car>();
    doSomething1(vec); // this is ok 
    doSomething2(vec); // this will give a compilation error 
