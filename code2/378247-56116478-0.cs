csharp
// As extension method
public static string GetMethodName<T>(this T instance, Func<T, string> nameofMethod) where T : class
{
    return nameofMethod(instance);
}
// As static method
public static string GetMethodName<T>(Func<T, string> nameofMethod) where T : class
{
    return nameofMethod(default);
}
Usage:
csharp
public class Car
{
    public void Drive() { }
}
var car = new Car();
string methodName1 = car.GetMethodName(c => nameof(c.Drive));
var nullCar = new Car();
string methodName2 = nullCar.GetMethodName(c => nameof(c.Drive));
string methodName3 = GetMethodName<Car>(c => nameof(c.Drive));
