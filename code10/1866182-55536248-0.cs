    using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using System.Xml.Serialization;
	public class Program
	{
		public static void Main()
		{
			var root = new Vehicles
			{
				Items =
				{
					new Vehicle() { Name = "Car"},
					new Vehicle() { Name = "Truck"},
					new Vehicle() { Name = "Bike"}
				}
			};
			var xmlSerializer = new XmlSerializer(typeof(Vehicles));
			var memoryStream = new MemoryStream();
			TextWriter stringWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);
			xmlSerializer.Serialize(stringWriter, root);
			string xml = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
			//Make XML
			var obj = root;
			var xmlString = obj.XmlSerializeToString();
			//Make Object with Direct Deserialization
			var vehicles = xmlString.XmlDeserializeFromString<Vehicles>();
			//Make polymorphic object from generic vehicles with some "logic"
			var polymorphicVehicles = new List<Vehicle>();  // ******  THIS is the collection you requested!!!! *********
			// itterate all vehicles
			foreach (var item in vehicles.Items)
			{
				// use json serialization, because casting Parent to Child is not acceptable
				var jsonVehicle = JsonConvert.SerializeObject(item);
				// depending on the Name of the vehicle, create a corresponding object
				switch (item.Name)
				{
					case "Car":
						var aCar = JsonConvert.DeserializeObject<Car>(jsonVehicle);
						polymorphicVehicles.Add(aCar);
						break;
					case "Truck":
						var aTruck = JsonConvert.DeserializeObject<Truck>(jsonVehicle);
						polymorphicVehicles.Add(aTruck);
						break;
					case "Bike":
						var aBike = JsonConvert.DeserializeObject<Bike>(jsonVehicle);
						polymorphicVehicles.Add(aBike);
						break;
					default:
						break;
				}
			}
			// this is just to print it out!
			var jsonPolymorphicVehicles = JsonConvert.SerializeObject(polymorphicVehicles);
			Console.WriteLine("XML:");
			Console.WriteLine(xml);
			Console.WriteLine("");
			Console.WriteLine("Polymorphic to jason");
			Console.WriteLine(jsonPolymorphicVehicles);
			Console.WriteLine("");
			Console.WriteLine("Press key to exit!");
			Console.Read();
		}
	}
	public class Vehicle
	{
		public string Name = "Vehicle";
	}
	public class Car : Vehicle
	{
		public Car()
		{
			Name = "Car";
		}
	}
	public class Bike : Vehicle
	{
		public Bike()
		{
			Name = "Bike";
		}
	}
	public class Truck : Vehicle
	{
		public Truck()
		{
			Name = "Truck";
		}
	}
	public class Vehicles
	{
		public List<Vehicle> Items { get; } = new List<Vehicle>();
	}
	public static class MyStaticClass
	{
		public static T XmlDeserializeFromString<T>(this string objectData)
		{
			return (T)XmlDeserializeFromString(objectData, typeof(T));
		}
		public static string XmlSerializeToString(this object objectInstance)
		{
			var serializer = new XmlSerializer(objectInstance.GetType());
			var sb = new StringBuilder();
			using (TextWriter writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, objectInstance);
			}
			return sb.ToString();
		}
		public static object XmlDeserializeFromString(this string objectData, Type type)
		{
			var serializer = new XmlSerializer(type);
			object result;
			using (TextReader reader = new StringReader(objectData))
			{
				result = serializer.Deserialize(reader);
			}
			return result;
		}
	}
