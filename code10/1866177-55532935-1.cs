 xml
<Vehicles>
    <Car>...car things...</Car>
    <Bike>...bike things...</Bike>
    <Truck>...truck things...</Truck>
</Vehicles>
which can be achieved via:
 c#
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
[XmlInclude(typeof(Car))] // technically you only need XmlInclude
[XmlInclude(typeof(Bike))] // if you're using xsi:type resolution
[XmlInclude(typeof(Truck))] // but... it doesn't hurt us here
public abstract class Vehicle { }
public class Car : Vehicle { }
public class Truck : Vehicle { }
public class Bike : Vehicle { }
[XmlRoot("Vehicles")]
public class MyRoot
{
    [XmlElement("Car", Type = typeof(Car))]
    [XmlElement("Truck", Type = typeof(Truck))]
    [XmlElement("Bike", Type = typeof(Bike))]
    public List<Vehicle> Items { get; } = new List<Vehicle>();
}
static class P
{
    static void Main()
    {
        var root = new MyRoot
        {
            Items =
            {
                new Car(),
                new Bike(),
                new Truck(),
            }
        };
        var ser = new XmlSerializer(typeof(MyRoot));
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        ser.Serialize(Console.Out, root, ns);
    }
}
