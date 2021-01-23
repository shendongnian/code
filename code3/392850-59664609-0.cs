CSharp
var porsche = Porsche.FromCar(basicCar);
Here, "Porsche" is the child class and "Car" is the base class. The function would then look something like this:
CSharp
public class Porsche : Car
{
    public static Porsche FromCar(Car basicCar)
    {
        // Create a JSON string that represents the base class and its current values.
        var serializedCar = JsonConvert.SerializeObject(basicCar);
        // Deserialize that base class string into the child class.
        return JsonConvert.DeserializeObject<Porsche>(serializedCar);
    }
    // Other properties and functions of the class...
}
The trick here is, that properties that are available in the child but not the base, will be created with their default value, so null usually, depending on the type of the property. The deserialization also goes by the name of the property, so all properties are copied over.<br><br>
I didn't test this code, but it should work, as I've done this once or twice before. Hope it helps someone.
